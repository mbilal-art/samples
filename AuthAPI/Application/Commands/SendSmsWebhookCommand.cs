using MediatR;

namespace Application.Commands
{
    public class SendSmsWebhookCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public string AccountSid { get; set; }
        public string ApiVersion { get; set; }
        public string From { get; set; }
        public string MessageSid { get; set; }
        public string MessageStatus { get; set; }
        public string SmsSid { get; set; }
        public string SmsStatus { get; set; }
        public string To { get; set; }
    }
}
