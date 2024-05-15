using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP_Management.Application.Contracts.Infrastructure;
using MP_Management.Contracts.Persistence;
using MP_Management.Infrastructure.Mail;

namespace MP_Management.Infrastructure
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
