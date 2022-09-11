using Account.Command.Service.Handlers.Account;
using Account.Query.Service.Account;
using AccountMapper.Dto;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AccountApi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountQueryService _accountQueryService;
        private readonly IAccountCommandService _accountCommandService;
        private readonly IMediator _mediator;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountQueryService accountQueryService, IAccountCommandService accountCommandService, ILogger<AccountController> logger, IMediator mediator)
        {
            //_accountCommandService = accountCommandService;
            _mediator = mediator;
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
        [Route("GetAccountByType")]
        public async Task<IActionResult> GetAccountByType(string accountType)
        {
            try
            {
                return Ok(_accountQueryService.GetAccountEntity(accountType));
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

        [HttpGet]
        [Route("GetAccountById")]
        public IActionResult GetAccountById(int id)
        {
            try
            {
                return Ok(_accountQueryService.GetAccountById(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("NewAccount")]
        public async Task<IActionResult> NewAccount(CommandCreateAccountDto dto)
        {
            try
            {
                await _mediator.Publish(dto);
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
        public async Task<IActionResult> PutAccount(CommandUpdateAccountDto dto)
        {
            try
            {
                await _mediator.Publish(dto);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPatch]
        [Route("PatchClient")]
        public async Task<IActionResult> PatchClient(int id, [FromBody] JsonPatchDocument dto)
        {
            try
            {
                var f = dto;
                await _accountCommandService.UpdateClient(id, dto);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

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
