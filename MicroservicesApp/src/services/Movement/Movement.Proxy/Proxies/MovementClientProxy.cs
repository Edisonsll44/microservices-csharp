﻿using Microsoft.Extensions.Options;
using Movement.Mapper.Dto;
using Movement.Proxy;
using Newtonsoft.Json;

namespace Movement.Service.Proxies
{
    public class MovementClientProxy : IMovementClientProxy
    {
        private readonly ApiUrls _apiUrl;

        public MovementClientProxy(IOptions<ApiUrls> apiUrl)
        {
            _apiUrl = apiUrl.Value;
        }
        public async Task<int> GetClientId(string dni)
        {
            var response = await ExecuteApi(dni, "GetClientByIdentification", "identification");
            return response.ClientId;
        }


        public async Task<ClientDto> GetClient(string name)
        {
            var response = await ExecuteApi(name, "GetClientByName", "name");
            return response;
        }

        async Task<ClientDto> ExecuteApi(string parameter, string method, string parameterName)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl.UrlClient);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Client/" + method + "?" + parameterName + "=" + parameter);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    ClientDto dto = JsonConvert.DeserializeObject<ClientDto>(responseBody);
                    return dto;
                }
                else
                {
                    throw new Exception("Existen problemas al consultar, vuelva a intentar mas tarde");
                }
            }
            throw new Exception("Existen problemas al consultar, vuelva a intentar mas tarde");
        }

        async Task<IEnumerable<ClientDto>> ExecuteApiCollection()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl.UrlClient);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Client/GetClients");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    IEnumerable<ClientDto> dto = JsonConvert.DeserializeObject<IEnumerable<ClientDto>>(responseBody);
                    return dto;
                }
                else
                {
                    throw new Exception("Existen problemas al consultar, vuelva a intentar mas tarde");
                }
            }
            throw new Exception("Existen problemas al consultar, vuelva a intentar mas tarde");
        }

        public async Task<IEnumerable<ClientDto>> GetClients()
        {
            var response = await ExecuteApiCollection();
            return response;
        }
    }
}