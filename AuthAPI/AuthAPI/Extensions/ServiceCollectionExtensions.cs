using Application.Commands;
using FluentValidation.AspNetCore;
using MediatR;
using Messaging.Extensions;
using Service.CommandHandlers;

namespace AuthAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssembly(typeof(SendSmsCommandValidator).Assembly));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMessagingConfiguration(configuration);
            services.AddMediatR(typeof(SendVerificationSmsCommand).Assembly, typeof(SendVerificationSmsCommandHandler).Assembly);
        }
    }
}
