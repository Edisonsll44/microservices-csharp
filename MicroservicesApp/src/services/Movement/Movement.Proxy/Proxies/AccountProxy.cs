using AccountMapper.Dto;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Movement.Service.Proxies
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
            var response = await ExecuteApi(accountType, "GetAccountByType", "accountType");
            return response.CuentaId;
        }


        public async Task<string> GetAccountName(int idAccount)
        {
            var response = await ExecuteApi(idAccount.ToString(), "GetAccountById", "id");
            return response.TipoCuenta;
        }
        async Task<AccountDto> ExecuteApi(string parameter, string method, string parameterName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl.UrlAccount);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET
                HttpResponseMessage response = await client.GetAsync("api/v1/Account/" + method + "?" + parameterName + "=" + parameter);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    AccountDto dto = JsonConvert.DeserializeObject<AccountDto>(responseBody);
                    return dto;
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
