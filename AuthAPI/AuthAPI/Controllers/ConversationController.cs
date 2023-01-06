using Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversationController : TwilioController
    {
        private readonly ILogger<ConversationController> _logger;
        private readonly IMediator _mediator;

        public ConversationController(ILogger<ConversationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("InboundConversationReply")]
        public async Task<IActionResult> InboundSmsConversationReply([FromForm] InboundSmsReplyCommand command)
        {
            //uncomment for any customization
            //var result = await _mediator.Send(command);
            
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message(command.Body, command.To, command.From);

            return TwiML(messagingResponse);
        }

        [HttpPost("CreateConversation")]
        [ProducesResponseType(typeof(CreateConversationCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateConversation([FromBody] CreateConversationCommand command)
        {
            if (command == null || String.IsNullOrWhiteSpace(command.FriendlyConversationName))
                return BadRequest("Conversation name is required.");

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("CreateConversationParticipant")]
        [ProducesResponseType(typeof(CreateConversationParticipantCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateConversationParticipant([FromBody] CreateConversationParticipantCommand command)
        {
            if (command == null || String.IsNullOrWhiteSpace(command.ParticipantNumber))
                return BadRequest("Participant number is required.");

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("AddConversationParticipant")]
        [ProducesResponseType(typeof(AddConversationParticipantCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddConversationParticipant([FromBody] AddConversationParticipantCommand command)
        {
            if (command == null || String.IsNullOrWhiteSpace(command.Identity))
                return BadRequest("Participant conversation identity is required.");

            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}
