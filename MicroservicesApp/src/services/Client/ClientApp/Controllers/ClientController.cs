using Client.Mapper.Dto;
using Client.Service.Queries.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientQueryService _clientQueryService;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientQueryService clientQueryService, ILogger<ClientController> logger)
        {
            _clientQueryService = clientQueryService;
            _logger = logger;
        }


        [HttpGet]
        [Route("GetClient")]
        public async Task<IActionResult> GetClient(int id)
        {
            try
            {
                return Ok(_clientQueryService.GetClient(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("GetClientByIdentification")]
        public async Task<IActionResult> GetClientByIdentification(string identification)
        {
            try
            {
                return Ok(_clientQueryService.GetClient(identification));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("GetClients")]
        public IActionResult GetClients()
        {
            try
            {
                return Ok(_clientQueryService.GetClients());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("NewClient")]
        public async Task<IActionResult> NewClient(ClientDto dto)
        {
            try
            {
                await _clientQueryService.CreateClient(dto);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        [Route("PutClient")]
        public async Task<IActionResult> PutClient(ClientDto dto)
        {
            try
            {
                await _clientQueryService.UpdateClient(dto);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        //[HttpPatch]
        //[Route("PatchClient")]
        //public async Task<IActionResult> PatchClient(int id, [FromBody] JsonPatchDocument<ClientDto> dto)
        //{
        //    try
        //    {
        //        var f = dto;
        //        await _clientQueryService.UpdateClient(id, null);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e.Message);
        //        throw new Exception(e.Message);
        //    }
        //}

        [HttpDelete]
        [Route("DeleteClient")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                await _clientQueryService.DeleteClient(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
