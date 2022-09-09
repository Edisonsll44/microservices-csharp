using Client.Service.Queries.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        private readonly IClientQueryService _clientQueryService;
        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger, IClientQueryService clientQueryService)
        {
            _logger = logger;
            _clientQueryService = clientQueryService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<string> Get()
        {
            try
            {
                var t = _clientQueryService.GetClient(1);
                return t.Telefono;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return "Runinig......";
        }
    }
}