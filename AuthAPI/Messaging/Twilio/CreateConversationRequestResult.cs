using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Twilio
{
    public class CreateConversationRequestResult
    {
        public string AccountSid { get; set; }
        public string Sid { get; set; }
        public string ChatServiceSid { get; set; }
        public string MessagingServiceSid { get; set; }
        public string Status { get; set; }
    }
}
