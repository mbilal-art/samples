using Application.Commands;
using MediatR;
using Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CommandHandlers
{
    public class CreateConversationParticipantCommandHandler : IRequestHandler<CreateConversationParticipantCommand, CreateConversationParticipantCommandResult>
    {
        private readonly IConversationService _twilioConversationService;
        public CreateConversationParticipantCommandHandler(IConversationService twilioConversationService)
        {
            _twilioConversationService = twilioConversationService;
        }

        public async Task<CreateConversationParticipantCommandResult> Handle(CreateConversationParticipantCommand command, CancellationToken cancellationToken)
        {
            //get the ConversationSid from datasource (which is created using CreateConversationAsync) & provide it here to attach participant with that conversation.
            var result = await _twilioConversationService.CreateConversationParticipantAsync(command.ParticipantNumber, "<conversation-sid-here>");

            return new CreateConversationParticipantCommandResult()
            {
                IsSucceed = !String.IsNullOrEmpty(result.Sid),
                Message = !String.IsNullOrEmpty(result.Sid) ? "Conversation participant created successfully." : "Some error has been occurred while creating participant."
            };
        }
    }
}
