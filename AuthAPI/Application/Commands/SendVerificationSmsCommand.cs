using MediatR;

namespace Application.Commands
{
    public class SendVerificationSmsCommand : IRequest<SendVerificationSmsCommandResult>
    {
        public string To { get; set; }
        public string UserId { get; set; }
    }
}
