using Application.Commands;
using MediatR;
using Messaging;

namespace Service.CommandHandlers
{
    public class SendCodeVerificationCommandHandler : IRequestHandler<SendCodeVerificationCommand, SendCodeVerificationCommandResult>
    {
        private readonly ISmsMessagingService _smsMessagingService;

        public SendCodeVerificationCommandHandler(ISmsMessagingService smsMessagingService)
        {
            _smsMessagingService = smsMessagingService;
        }

        public async Task<SendCodeVerificationCommandResult> Handle(SendCodeVerificationCommand command, CancellationToken cancellationToken)
        {
            var result = await _smsMessagingService.VerifySmsTokenAsync(command.To, command.Code);

            return new SendCodeVerificationCommandResult()
            {
                IsSucceed = result,
                Message = result ? "User is successfully verified." : "Verification failed. Invalid code is provided."
            };
        }
    }
}
