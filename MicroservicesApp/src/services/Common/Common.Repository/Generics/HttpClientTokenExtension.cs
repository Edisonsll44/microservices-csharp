using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Common.Repository.Generics
{
    public static class HttpClientTokenExtension
    {
        public static void AddBearerToken(this HttpClient client, HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated && context.Request.Headers.ContainsKey("Authorization"))
            {
                var token = context.Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                }
            }
        }
    }
}
