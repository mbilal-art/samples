using MediatR;

namespace Application.Commands
{
    public class CreateConversationCommand : IRequest<CreateConversationCommandResult>
    {
        public string FriendlyConversationName { get; set; }
    }
}
