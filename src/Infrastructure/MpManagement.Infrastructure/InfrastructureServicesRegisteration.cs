using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MpManagement.Application.Contracts.Infrastructure;
using MpManagement.Infrastructure.Mail;

namespace MpManagement.Infrastructure
{
	public static class InfrastructureServicesRegisteration
	{
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
			services.Configure<EmailSender>(configuration.GetSection("EmailSettings"));
			services.AddTransient<IEmailSender, EmailSender>();
			return services;
		}
    }
}
