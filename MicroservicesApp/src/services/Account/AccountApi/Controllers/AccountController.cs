using Account.Command.Service;
using Account.Query.Service;
using AccountMapper.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountQueryService _accountQueryService;
        private readonly IAccountCommandService _accountCommandService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountQueryService accountQueryService, IAccountCommandService accountCommandService, ILogger<AccountController> logger)
        {
            _accountCommandService = accountCommandService;
            _accountQueryService = accountQueryService;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetAccount")]
        public async Task<IActionResult> GetAccount(int id)
        {
            try
            {
                return Ok(_accountQueryService.GetAccount(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("GetAccounts")]
        public IActionResult GetClients()
        {
            try
            {
                return Ok(_accountQueryService.GetAccounts());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("NewAccount")]
        public async Task<IActionResult> NewAccount(AccountDto dto)
        {
            try
            {
                await _accountCommandService.CreateAccount(dto);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        [Route("PutAccount")]
        public async Task<IActionResult> PutAccount(AccountDto dto)
        {
            try
            {
                await _accountCommandService.UpdateAccount(dto);
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
        [Route("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                await _accountCommandService.DeleteAccount(id);
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
