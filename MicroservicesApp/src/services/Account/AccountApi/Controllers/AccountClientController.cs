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
        private readonly ILogger<AccountClientController> _logger;

        public AccountClientController(IMediator mediator, ILogger<AccountClientController> logger)
        {
            _mediator = mediator;
            _logger = logger;
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
    }
}
