using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MP_Management.Application
{
	public static class ApplicationServiceRegisteration
	{
		public static void ConfigureApplicationServices(this IServiceCollection services)
		{
			// services.AddAutoMapper(typeof(MappingProfile));

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
		}
	}
}
