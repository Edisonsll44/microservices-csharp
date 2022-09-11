using Client.Mapper.Dto;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text.Json;

namespace Account.Service.Proxies
{
    public class ClientProxy : IClientProxy
    {
        private readonly ApiUrls _apiUrl;

        public ClientProxy(IOptions<ApiUrls> apiUrl)
        {
            _apiUrl = apiUrl.Value;
        }
        public async Task<int> GetClientId(string dni)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl.UrlClient);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Client/GetClientByIdentification?identification=" + dni);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    ClientDto dto = JsonConvert.DeserializeObject<ClientDto>(responseBody);
                    return dto.ClientId;
                }
                else
                {
                    throw new Exception("Existen problemas al consultar, vuelva a intentar mas tarde");
                }
            }
            throw new Exception("Existen problemas al consultar, vuelva a intentar mas tarde");
        }
    }
}
