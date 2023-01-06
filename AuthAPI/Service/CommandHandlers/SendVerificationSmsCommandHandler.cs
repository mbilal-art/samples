using Application.Commands;
using MediatR;
using Messaging;

namespace Service.CommandHandlers
{
    public class SendVerificationSmsCommandHandler : IRequestHandler<SendVerificationSmsCommand, SendVerificationSmsCommandResult>
    {
        private readonly ISmsMessagingService _smsMessagingService;
        public SendVerificationSmsCommandHandler(ISmsMessagingService smsMessagingService)
        {
            _smsMessagingService = smsMessagingService;
        }

        public async Task<SendVerificationSmsCommandResult> Handle(SendVerificationSmsCommand command, CancellationToken cancellationToken)
        {
            var result = await _smsMessagingService.SendVerificationSmsAsync(command.To);

            if (!result)
                throw new InvalidOperationException("Some error occurred while sending verification sms. Please contact admin support.");

            return new SendVerificationSmsCommandResult()
            {
                IsSucceed = result,
                Message = "Verification code sent to your number."
            };
        }
    }
}
