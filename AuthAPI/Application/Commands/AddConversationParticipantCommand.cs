using MediatR;

namespace Application.Commands
{
    public class AddConversationParticipantCommand : IRequest<AddConversationParticipantCommandResult>
    {
        public string Identity { get; set; }
    }
}
