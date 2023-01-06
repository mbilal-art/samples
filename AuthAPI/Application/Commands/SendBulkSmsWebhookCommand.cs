using MediatR;
using Newtonsoft.Json;

namespace Application.Commands
{
    public class SendBulkSmsWebhookCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public string AccountSid { get; set; }
        public int Count { get; set; }
        public string DeliveryState { get; set; }
        public DeliveryState ParsedDeliveryState { get; set; }
        public bool IsFinal { get; set; }
        public string NotificationSid { get; set; }
        public int SequenceId { get; set; }
        public string ServiceSid { get; set; }
    
        public void DeserializeDeliveryStatus()
        {
            if(!String.IsNullOrEmpty(this.DeliveryState))
                this.ParsedDeliveryState = JsonConvert.DeserializeObject<DeliveryState>(this.DeliveryState);
        }
    }

    public class DeliveryState
    {
        [JsonProperty("status")]
        protected string Status { get; set; }
        [JsonProperty("type")]
        protected string Type { get; set; }
        [JsonProperty("sid")]
        protected string Sid { get; set; }
    }
}
