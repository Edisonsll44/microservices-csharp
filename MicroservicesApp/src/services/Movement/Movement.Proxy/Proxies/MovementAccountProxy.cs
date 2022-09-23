using Microsoft.Extensions.Options;
using Movement.Mapper.Dto;
using Movement.Proxy;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Movement.Service.Proxies
{
    public class MovementAccountProxy : IMovementAccountProxy
    {
        private readonly ApiUrls _apiUrl;


        public MovementAccountProxy(IOptions<ApiUrls> apiUrl)
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

        public async Task<IEnumerable<CommandCreateAccountClientDto>> GetAccountsByClient(int clientId, string clientName, string dni)
        {
            string url = "";
            if (clientId != 0 && string.IsNullOrEmpty(dni) && string.IsNullOrEmpty(clientName))
                url = "AccountClient/GetAccountsClient?clientId=" + clientId;

            if (clientId != 0 && !string.IsNullOrEmpty(clientName) && string.IsNullOrEmpty(dni))
                url = "AccountClient/GetAccountsClient?clientId=" + clientId + "&clientName=" + clientName;

            if (clientId != 0 && !string.IsNullOrEmpty(dni) && string.IsNullOrEmpty(clientName))
                url = "AccountClient/GetAccountsClient?clientId=" + clientId + "&dni=" + dni;

            if (!string.IsNullOrEmpty(clientName) && !string.IsNullOrEmpty(dni) && clientId == 0)
                url = "AccountClient/GetAccountsClient?clientId=" + clientId + "&dni=" + dni;

            if (clientId != 0 && !string.IsNullOrEmpty(clientName) && !string.IsNullOrEmpty(dni))
                url = "AccountClient/GetAccountsClient?clientId=" + clientId + "&clientName=" + clientName + "&dni=" + dni;

            var response = await ExecuteApi(url);
            return (IEnumerable<CommandCreateAccountClientDto>)response;
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

        async Task<CommandCreateAccountClientDto> ExecuteApi(string query)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl.UrlAccount);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET
                HttpResponseMessage response = await client.GetAsync("api/v1/Account/" + query);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    CommandCreateAccountClientDto dto = JsonConvert.DeserializeObject<CommandCreateAccountClientDto>(responseBody);
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
