using Messaging.Twilio;

namespace Messaging
{
    public interface ISmsMessagingService
    {
        Task<SendVerificationSmsRequestResult> SendVerificationSmsAsync(string to);
        Task<VerifySmsTokenRequestResult> VerifySmsTokenAsync(string to, string code);
        Task<SendSingleSmsRequestResult> SendSingleSmsAsync(string to, string subject, string body, string userId = "", string companyId = "");
        Task<SendBulkSmsRequestResult> SendBulkSmsAsync(List<string> to, string subject, string body, string userId = "", string companyId = "");
    }
}
