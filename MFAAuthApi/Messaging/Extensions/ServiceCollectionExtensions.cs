using Messaging.Configuration;
using Messaging.Twilio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessagingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISmsMessagingService, TwilioSmsService>();
            services.AddScoped(config =>
            {
                var exception = new InvalidOperationException("Twilio Configuration is missing.");
                return new MessagingConfiguration()
                {
                    TwilioConfiguation = new TwilioConfiguation()
                    {
                        AccountSID = !String.IsNullOrEmpty(configuration["Twilio:AccountSid"]) ? configuration["Twilio:AccountSid"] : throw exception,
                        AuthToken = !String.IsNullOrEmpty(configuration["Twilio:AuthToken"]) ? configuration["Twilio:AuthToken"] : throw exception,
                        VerifyServiceSID = !String.IsNullOrEmpty(configuration["Twilio:VerifyServiceSid"]) ? configuration["Twilio:VerifyServiceSid"] : throw exception,
                        NotifyMessagingServiceSid = !String.IsNullOrEmpty(configuration["Twilio:NotifyMessagingServiceSid"]) ? configuration["Twilio:NotifyMessagingServiceSid"] : throw exception,
                        From = !String.IsNullOrEmpty(configuration["Twilio:From"]) ? configuration["Twilio:From"] : throw exception,
                        StatusCallbackUri = !String.IsNullOrEmpty(configuration["Twilio:StatusCallbackUri"]) ? configuration["Twilio:StatusCallbackUri"] : throw exception,
                        DeliveryCallbackUrl = !String.IsNullOrEmpty(configuration["Twilio:DeliveryCallbackUrl"]) ? configuration["Twilio:DeliveryCallbackUrl"] : throw exception
                    }
                };
            });

            return services;
        }
    }
}
