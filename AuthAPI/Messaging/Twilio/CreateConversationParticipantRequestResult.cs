using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.Twilio
{
    public class CreateConversationParticipantRequestResult
    {
        public string Sid { get; set; }
        public string AccountSid { get; set; }
        public string Identity { get; set; }
        public string ConversationSid { get; set; }
    }
}
