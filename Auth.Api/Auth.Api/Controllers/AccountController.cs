using Application.Commands.Account;
using Application.Queries.Account;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;

        public AccountController(ILogger<AccountController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserAccountCreateCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create([FromForm]UserAccountCreateCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch(InvalidOperationException ex)
            {
                return Conflict(ex);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(UserAccountUpdateCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update([FromForm]UserAccountUpdateCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete([FromQuery] UserAccountDeleteCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserAccountByIdQueryResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var query = new GetUserAccountByIdQuery(){ Id = id };
                 var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex);
            }
        }
    }
}