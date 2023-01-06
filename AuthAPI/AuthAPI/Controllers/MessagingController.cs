using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagingController : ControllerBase
    {
        private readonly ILogger<MessagingController> _logger;
        private readonly IMediator _mediator;

        public MessagingController(ILogger<MessagingController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("SendSms")]
        [ProducesResponseType(typeof(SendSmsCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> SendSms([FromBody] SendSmsCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex);
            }
        }

        [HttpPost("SmsWebhook")]
        public async Task<IActionResult> SendSmsWebhook(string userId, string companyId, [FromForm] SendSmsWebhookCommand command)
        {
            command.UserId = userId;
            command.CompanyId = companyId;

            await _mediator.Send(command);
            return Content("Handled");
        }

        [HttpPost("SendBulkSms")]
        [ProducesResponseType(typeof(SendBulkSmsCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> SendBulkSms([FromBody] SendBulkSmsCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex);
            }
        }

        [HttpPost("BulkSmsWebhook")]
        public async Task<IActionResult> SendBulkSmsWebhook(string userId, string companyId, [FromForm] SendBulkSmsWebhookCommand command)
        {
            command.UserId = userId;
            command.CompanyId = companyId;
            command.DeserializeDeliveryStatus();

            await _mediator.Send(command);
            return Content("Handled");
        }


        [HttpPost("SendVerification")]
        [ProducesResponseType(typeof(SendVerificationSmsCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> SendVerificationMessage([FromBody] SendVerificationSmsCommand command)
        {
            try
            {
                if (command == null || String.IsNullOrWhiteSpace(command.To))
                    return BadRequest("Invalid request or Phone number is empty.");

                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex);
            }
        }

        [HttpPost("SendCodeVerification")]
        [ProducesResponseType(typeof(SendCodeVerificationCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> SendCodeVerification([FromBody] SendCodeVerificationCommand command)
        {
            if (command == null || String.IsNullOrWhiteSpace(command.To) || String.IsNullOrWhiteSpace(command.Code))
                return BadRequest("Invalid request or Phone number/Code is empty.");

            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}