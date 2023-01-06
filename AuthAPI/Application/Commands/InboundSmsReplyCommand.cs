using MediatR;

namespace Application.Commands
{
    public class InboundSmsReplyCommand : IRequest<InboundSmsReplyCommandResult>
    {
        public string SmsMessageSid { get; set; }
        public int NumMedia { get; set; }
        public string ProfileName { get; set; }
        public string SmsSid { get; set; }
        public string WaId { get; set; }
        public string SmsStatus { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public int NumSegments { get; set; }
        public string MessageSid { get; set; }
        public string AccountSid { get; set; }
        public string From { get; set; }
        public string ApiVersion { get; set; }
    }
}
