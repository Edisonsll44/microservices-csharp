using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movement.Command.Service;
using Movement.Mapper.Dto;
using Movement.Query.Service;
using Movement.Rules.Business;

namespace Movement.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IMovementCommandService _movementCommandService;
        private readonly IMovementQueryService _movementQueryService;
        private readonly ILogger<MovementController> _logger;
        private readonly IBalanceValidator _balanceValidator;

        public MovementController(IMovementCommandService movementCommandService, IMovementQueryService movementQueryService, ILogger<MovementController> logger, IBalanceValidator balanceValidator)
        {
            _movementCommandService = movementCommandService;
            _movementQueryService = movementQueryService;
            _balanceValidator = balanceValidator;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetMovement")]
        public async Task<IActionResult> GetMovement(int id)
        {
            try
            {
                return Ok(_movementQueryService.GetMovemment(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("GetMovements")]
        public IActionResult GetMovements()
        {
            try
            {
                return Ok(_movementQueryService.GetMovemments());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        [Route("NewMovement")]
        public async Task<IActionResult> NewMovement(MovementDto dto)
        {
            try
            {
                await _balanceValidator.BalanceCeroValidator(dto);
                await _movementCommandService.CreateMovement(dto);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        [Route("PutMovement")]
        public async Task<IActionResult> PutMovement(MovementDto dto)
        {
            try
            {
                await _movementCommandService.UpdateMovement(dto);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteClient")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                await _movementCommandService.DeleteteMovement(id);
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
