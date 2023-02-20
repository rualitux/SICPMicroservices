using AutoMapper;
using EnumeradoService;
using Grpc.Net.Client;
using InventarioService.Models;

namespace InventarioService.SyncDataServices.Grpc
{
    public class EnumeradoDataClient : IEnumeradoDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public EnumeradoDataClient(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        public IEnumerable<Enumerado> ReturnAlLEnumerados()
        {
            Console.WriteLine($"Llamando GrpcService: {_configuration["GrpcEnumerado"]}");
            var channel = GrpcChannel.ForAddress(_configuration["GrpcEnumerado"]);
            //Salen de enumerados.proto
            var client = new GrpcEnumerado.GrpcEnumeradoClient(channel);            
            //dummy request
            var request = new GetAllRequest();
            try
            {
                var reply = client.GetAllEnumerados(request);
                return _mapper.Map<IEnumerable<Enumerado>>(reply.Enumerado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo llamar GrpcService {ex.Message}");
                return null;
            }
        }
    }
}
