using Application.Commands;
using MediatR;
using Messaging;

namespace Service.CommandHandlers
{
    public class SendSmsCommandHandler : IRequestHandler<SendSmsCommand, SendSmsCommandResult>
    {
        private readonly ISmsMessagingService _smsMessagingService;

        public SendSmsCommandHandler(ISmsMessagingService smsMessagingService)
        {
            _smsMessagingService = smsMessagingService;
        }

        public async Task<SendSmsCommandResult> Handle(SendSmsCommand command, CancellationToken cancellationToken)
        {
            var result = await _smsMessagingService.SendSingleSmsAsync(command.To, command.Subject, command.Body);

            return new SendSmsCommandResult()
            {
                IsSucceed = true,
                Status =  result.Status
            };
        }
    }
}
