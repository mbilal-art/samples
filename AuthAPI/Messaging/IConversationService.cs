using Messaging.Twilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public interface IConversationService
    {
        Task<CreateConversationRequestResult> CreateConversationAsync(string conversationFriendlyName);
        Task<CreateConversationParticipantRequestResult> CreateConversationParticipantAsync(string participantNumber, string conversationSid);
        Task<AddConversationParticipantRequestResult> AddConversationParticipant(string identity, string conversationSid);
        Task<ConversationAccessTokenRequestResult> GetConversationAccessTokenAgainstIdentity(string identity, string conversationSid);
    }
}
