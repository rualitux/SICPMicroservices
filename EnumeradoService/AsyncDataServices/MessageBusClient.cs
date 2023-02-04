using EnumeradoService.Dtos;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace EnumeradoService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory() {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"])};
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
                Console.WriteLine("Conectado a MBus");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--->No se pudo conectar al MBus: {ex.Message}");
            }    
        
        }

        public void PublicarEnumerado(EnumeradoPublishedDto enumeradoPublishedDto)
        {
            var message = JsonSerializer.Serialize(enumeradoPublishedDto);
            if (_connection.IsOpen)
            {
                Console.WriteLine("---> Conexión RabbitMQ abierta, mandando mensajito..");
                SendMessage(message); 
            }
            else 
            {
                Console.WriteLine("--> RabbitMQ cerró, no se manda nada..");
            }
        }
        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(
                exchange: "trigger",
                routingKey: "",
                basicProperties: null,
                body: body);
            Console.WriteLine($"-->Se mandó {message}");
        }

        public void Dispose() 
        {
            Console.WriteLine("MBus disposed");
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }
        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("--_> RabbitMQ murió ");          
        }
    }
        

 
    }
