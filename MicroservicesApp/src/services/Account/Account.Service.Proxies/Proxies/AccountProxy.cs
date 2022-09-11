using AccountMapper.Dto;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Account.Service.Proxies
{
    public class AccountProxy : IAccountProxy
    {
        private readonly ApiUrls _apiUrl;


        public AccountProxy(IOptions<ApiUrls> apiUrl)
        {
            _apiUrl = apiUrl.Value;
        }

        public async Task<int> GetAccountIdAsync(string accountType)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl.UrlAccount);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET
                HttpResponseMessage response = await client.GetAsync("api/v1/Account/GetAccountByType?accountType=" + accountType);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    AccountDto dto = JsonConvert.DeserializeObject<AccountDto>(responseBody);
                    return dto.CuentaId;
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
