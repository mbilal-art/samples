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
    public class AddConversationParticipantCommandHandler : IRequestHandler<AddConversationParticipantCommand, AddConversationParticipantCommandResult>
    {
        private readonly IConversationService _twilioConversationService;
        public AddConversationParticipantCommandHandler(IConversationService twilioConversationService)
        {
            _twilioConversationService = twilioConversationService;
        }

        public async Task<AddConversationParticipantCommandResult> Handle(AddConversationParticipantCommand command, CancellationToken cancellationToken)
        {
            //get the ConversationSid from datasource (which is created using CreateConversationAsync) & provide it here to attach participant with that conversation.
            var result = await _twilioConversationService.AddConversationParticipant(command.Identity, "<conversation-sid-here>");

            return new AddConversationParticipantCommandResult()
            {
                IsSucceed = !String.IsNullOrEmpty(result.Sid),
                Message = !String.IsNullOrEmpty(result.Sid) ? "Conversation participant identity added successfully." : "Some error has been occurred while adding participant identity."
            };
        }
    }
}
