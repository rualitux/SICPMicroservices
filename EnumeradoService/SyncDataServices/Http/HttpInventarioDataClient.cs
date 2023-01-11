using EnumeradoService.Dtos;
using System.Text;
using System.Text.Json;

namespace EnumeradoService.SyncDataServices.Http
{
    public class HttpInventarioDataClient : IInventarioDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpInventarioDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

        }
        
        public async Task SendEnumeradoToInventario(EnumeradoReadDto enumerado)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(enumerado),
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync($"{_configuration["InventarioService"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("OK: Sync POST a Inventario Service piola");
            }
            else
            {
                Console.WriteLine("EEROR: Sync POST a Inventario Service falló");

            }

        }
    }
}
