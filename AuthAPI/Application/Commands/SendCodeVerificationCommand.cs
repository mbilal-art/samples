using MediatR;

namespace Application.Commands
{
    public class SendCodeVerificationCommand : IRequest<SendCodeVerificationCommandResult>
    {
        public string To { get; set; }
        public string Code { get; set; }
    }
}
