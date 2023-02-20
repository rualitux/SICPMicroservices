using AutoMapper;
using EnumeradoService.Interfaces;
using Grpc.Core;

namespace EnumeradoService.AsyncDataServices.Grpc
{
    public class GrpcEnumeradoService: GrpcEnumerado.GrpcEnumeradoBase
    {
        private readonly IEnumeradoRepository _repository;
        private readonly IMapper _mapper;

        public GrpcEnumeradoService(IEnumeradoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public override Task<EnumeradoResponse> GetAllEnumerados(GetAllRequest request, ServerCallContext context)
        {
            var response = new EnumeradoResponse();
            var enumerados = _repository.GetAllEnumerado();

            foreach (var enumerado in enumerados)
            {
               
                response.Enumerado.Add(_mapper.Map<GrpcEnumeradoModel>(enumerado));
            }

            return Task.FromResult(response);

        }
    }
}
