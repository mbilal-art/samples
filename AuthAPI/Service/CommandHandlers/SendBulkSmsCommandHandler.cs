using Application.Commands;
using MediatR;
using Messaging;

namespace Service.CommandHandlers
{
    public class SendBulkSmsCommandHandler : IRequestHandler<SendBulkSmsCommand, SendBulkSmsCommandResult>
    {
        private readonly ISmsMessagingService _smsMessagingService;

        public SendBulkSmsCommandHandler(ISmsMessagingService smsMessagingService)
        {
            _smsMessagingService = smsMessagingService;
        }

        public async Task<SendBulkSmsCommandResult> Handle(SendBulkSmsCommand command, CancellationToken cancellationToken)
        {
            var result = await _smsMessagingService.SendBulkSmsAsync(command.To, command.Subject, command.Body);

            return new SendBulkSmsCommandResult()
            {
                IsSucceed = true,
                Status = result.Status
            };
        }
    }
}
