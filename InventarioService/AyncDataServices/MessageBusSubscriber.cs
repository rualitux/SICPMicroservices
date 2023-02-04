using InventarioService.EventProcesamiento;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace InventarioService.AyncDataServices
{
    public class MessageBusSubscriber : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IEventProcesador _eventProcesador;
        private IConnection _connection;
        private IModel _channel;
        private string _colaNombre;

        public MessageBusSubscriber(IConfiguration configuration, IEventProcesador eventProcesador)
        {
            _configuration = configuration;
            _eventProcesador = eventProcesador;
            InicializarRabbitMQ();
        }
        //crea la conexión
        private void InicializarRabbitMQ()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"])
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
            _colaNombre = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _colaNombre,
                exchange: "trigger",
                routingKey: "");
            Console.WriteLine("--> Atento al MessageBus");
            _connection.ConnectionShutdown += RabbitMQApagar;
        }
        private void RabbitMQApagar(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("--> Conexión apagada");
        }
        public override void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
            base.Dispose();
        }

        //Long running task que espera y escucha x eventos
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ModuleHandle, ea) =>
            {
                Console.WriteLine("xXEvento recibidoXx");
                var body = ea.Body;
                var notificacionMessage = Encoding.UTF8.GetString(body.ToArray());
                _eventProcesador.ProcessEvent(notificacionMessage);
            };
            _channel.BasicConsume(queue: _colaNombre, autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
