using Messaging.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Conversations.V1;
using Twilio.Rest.Conversations.V1.Conversation;
using Twilio.Rest.Verify.V2.Service;

namespace Messaging.Twilio
{
    public class TwilioConversationService : IConversationService
    {
        private readonly MessagingConfiguration _messagingConfiguration;
        public TwilioConversationService(MessagingConfiguration messagingConfiguration)
        {
            _messagingConfiguration = messagingConfiguration;
        }

        public async Task<CreateConversationRequestResult> CreateConversationAsync(string conversationFriendlyName)
        {
            TwilioClient.Init(_messagingConfiguration.TwilioConfiguation.AccountSID, _messagingConfiguration.TwilioConfiguation.AuthToken);

            var conversation = ConversationResource.Create(
                friendlyName: conversationFriendlyName
            );

            return new CreateConversationRequestResult()
            {
                Sid = conversation.Sid,
                Status = conversation.State.ToString(),
                AccountSid = conversation.AccountSid,
                ChatServiceSid = conversation.ChatServiceSid,
                MessagingServiceSid = conversation.MessagingServiceSid,
            };
        }

        public async Task<CreateConversationParticipantRequestResult> CreateConversationParticipantAsync(string participantNumber, string conversationSid)
        {
            TwilioClient.Init(_messagingConfiguration.TwilioConfiguation.AccountSID, _messagingConfiguration.TwilioConfiguation.AuthToken);

            var participant = ParticipantResource.Create(
                messagingBindingAddress: participantNumber,
                messagingBindingProxyAddress: _messagingConfiguration.TwilioConfiguation.From,
                pathConversationSid: conversationSid
            );

            return new CreateConversationParticipantRequestResult()
            {
                Sid = participant.Sid,
                AccountSid = participant.AccountSid,
                ConversationSid = participant.ConversationSid,
                Identity = participant.Identity,
            };
        }

        public async Task<AddConversationParticipantRequestResult> AddConversationParticipant(string identity, string conversationSid)
        {
            TwilioClient.Init(_messagingConfiguration.TwilioConfiguation.AccountSID, _messagingConfiguration.TwilioConfiguation.AuthToken);

            var participant = ParticipantResource.Create(
                identity: identity,
                pathConversationSid: conversationSid
            );

            return new AddConversationParticipantRequestResult()
            {
                Sid = participant.Sid,
                AccountSid = participant.AccountSid,
                ConversationSid = participant.ConversationSid,
                Identity = participant.Identity,
            };
        }

        public async Task<ConversationAccessTokenRequestResult> GetConversationAccessTokenAgainstIdentity(string identity, string conversationSid)
        {
            TwilioClient.Init(_messagingConfiguration.TwilioConfiguation.AccountSID, _messagingConfiguration.TwilioConfiguation.AuthToken);

            var accessToken = AccessTokenResource.Create(
                identity: identity,
                factorType: AccessTokenResource.FactorTypesEnum.Push,
                pathServiceSid: conversationSid
            );

            return new ConversationAccessTokenRequestResult()
            {
                Token = accessToken.Token
            };
        }

        public async Task<GetConversationRequestResult> GetConversationAsync(string conversationSid)
        {
            TwilioClient.Init(_messagingConfiguration.TwilioConfiguation.AccountSID, _messagingConfiguration.TwilioConfiguation.AuthToken);

            var conversation = ConversationResource.Fetch(
                pathSid: conversationSid
            );

            return new GetConversationRequestResult()
            {
                Sid = conversation.Sid,
                Status = conversation.State.ToString(),
                AccountSid = conversation.AccountSid,
                ChatServiceSid = conversation.ChatServiceSid,
                MessagingServiceSid = conversation.MessagingServiceSid,
            };
        }

    }
}
