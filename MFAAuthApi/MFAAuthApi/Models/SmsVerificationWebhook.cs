using Newtonsoft.Json;

namespace MFAAuthApi.Models
{
    public class SmsVerificationWebhook
    {
        [JsonProperty("factor_sid")]
        public string VerifySid { get; set; }

        [JsonProperty("type")]
        public string Status { get; set; }
    }
}
