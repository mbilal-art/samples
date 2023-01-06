using MediatR;

namespace Application.Commands
{
    public class CreateConversationParticipantCommand : IRequest<CreateConversationParticipantCommandResult>
    {
        public string ParticipantNumber { get; set; }
    }
}
