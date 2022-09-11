using Account.Query.Service;
using AccountMapper.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAccountClientQueryService _accountClientQueryService;
        private readonly ILogger<AccountClientController> _logger;

        public AccountClientController(IMediator mediator, ILogger<AccountClientController> logger, IAccountClientQueryService accountClientQueryService)
        {
            _mediator = mediator;
            _logger = logger;
            _accountClientQueryService = accountClientQueryService;
        }


        [HttpPost]
        [Route("NewAccountClient")]
        public async Task<IActionResult> NewAccountClient(CommandCreateAccountClientDto dto)
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

        [HttpPost]
        [Route("GetAccountsClients")]
        public async Task<IActionResult> GetAccountsClients(CommandCreateAccountClientDto dto)
        {
            try
            {
                var response = await _accountClientQueryService.GetAccountsByClientsAsync();
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("GetAccountClient")]
        public async Task<IActionResult> GetAccountClient(string nameClient)
        {
            try
            {
                var response = await _accountClientQueryService.GetAccountByNameAsync(nameClient);
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
