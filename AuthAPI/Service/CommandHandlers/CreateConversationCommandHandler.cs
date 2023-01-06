using Application.Commands;
using MediatR;
using Messaging;

namespace Service.CommandHandlers
{
    public class CreateConversationCommandHandler : IRequestHandler<CreateConversationCommand, CreateConversationCommandResult>
    {
        private readonly IConversationService _twilioConversationService;
        public CreateConversationCommandHandler(IConversationService twilioConversationService)
        {
            _twilioConversationService = twilioConversationService;
        }

        public async Task<CreateConversationCommandResult> Handle(CreateConversationCommand command, CancellationToken cancellationToken)
        {
            var result = await _twilioConversationService.CreateConversationAsync(command.FriendlyConversationName);

            //use result.Sid as a unique identifier & for later use

            return new CreateConversationCommandResult()
            {
                IsSucceed = !String.IsNullOrEmpty(result.Sid),
                Status = result.Status,
                Message = !String.IsNullOrEmpty(result.Sid) ? "Conversation created successfully." : "Some error has been occurred while creating conversation."
            };
        }
    }
}
