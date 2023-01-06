namespace Messaging.Configuration
{
    public class TwilioConfiguation
    {
        public string AccountSID { get; set; }
        public string AuthToken { get; set; }
        public string VerifyServiceSID { get; set; }
        public string NotifyMessagingServiceSid { get; set; }
        public string From { get; set; }
        public string StatusCallbackUri { get; set; }
        public string DeliveryCallbackUrl { get; set; }
    }
}
