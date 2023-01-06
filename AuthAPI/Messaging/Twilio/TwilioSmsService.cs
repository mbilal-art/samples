using Twilio;
using Messaging.Configuration;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using Notify = Twilio.Rest.Notify.V1.Service;
using Twilio.Types;

namespace Messaging.Twilio
{
    public class TwilioSmsService : ISmsMessagingService
    {
        private readonly MessagingConfiguration _messagingConfiguration;
        public TwilioSmsService(MessagingConfiguration messagingConfiguration)
        {
            _messagingConfiguration = messagingConfiguration;
        }

        public async Task<SendSingleSmsRequestResult> SendSingleSmsAsync(string to, string subject, string body, string userId = "", string companyId = "")
        {
            TwilioClient.Init(_messagingConfiguration.TwilioConfiguation.AccountSID, _messagingConfiguration.TwilioConfiguation.AuthToken);

            var message = MessageResource.Create(
                body: $"{subject}\n\n{body}",
                from: new PhoneNumber($"whatsapp:{_messagingConfiguration.TwilioConfiguation.From}"),
                to: new PhoneNumber($"whatsapp:{to}"),
                statusCallback: new Uri($"{_messagingConfiguration.TwilioConfiguation.StatusCallbackUri}?userId={userId}&companyId={companyId}")
            );

            return new SendSingleSmsRequestResult(){
                Sid = message.Sid,
                Status = message.Status.ToString()
            };
        }

        public async Task<SendBulkSmsRequestResult> SendBulkSmsAsync(List<string> to, string subject, string body, string userId = "", string companyId = "")
        {
            var tos = new List<string>();
            to.ForEach(x =>
            {
                tos.Add("{\"binding_type\":\"sms\",\"address\":\"" + x + "\"}");
            });

            var notification = Notify.NotificationResource.Create(
                _messagingConfiguration.TwilioConfiguation.NotifyMessagingServiceSid,
                toBinding: tos,
                body: $"{subject}\n\n{body}",
                deliveryCallbackUrl: $"{_messagingConfiguration.TwilioConfiguation.DeliveryCallbackUrl}?userId={userId}&companyId={companyId}"
            );

            return new SendBulkSmsRequestResult()
            {
                Sid = notification.Sid,
                Status = "queued"
            };
        }

        public Task<bool> SendVerificationSmsAsync(string to)
        {
            TwilioClient.Init(_messagingConfiguration.TwilioConfiguation.AccountSID, _messagingConfiguration.TwilioConfiguation.AuthToken);

            var verification = VerificationResource.Create(
                to: to,
                channel: "sms",
                pathServiceSid: _messagingConfiguration.TwilioConfiguation.VerifyServiceSID
            );

            return Task.FromResult(verification.Status == "pending" || verification.Status == "approved");
        }

        public Task<bool> VerifySmsTokenAsync(string to, string code)
        {
            TwilioClient.Init(_messagingConfiguration.TwilioConfiguation.AccountSID, _messagingConfiguration.TwilioConfiguation.AuthToken);

            var verificationCheck = VerificationCheckResource.Create(
                to: to,
                code: code,
                pathServiceSid: _messagingConfiguration.TwilioConfiguation.VerifyServiceSID
            );

            return Task.FromResult(verificationCheck.Status == "approved");
        }
    }
}
