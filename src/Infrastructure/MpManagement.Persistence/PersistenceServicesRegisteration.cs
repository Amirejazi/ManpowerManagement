using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MpManagement.Persistence.Context;
using MpManagement.Application.Contracts.Persistence;
using MpManagement.Persistence.Repositories;

namespace MpManagement.Persistence
{
	public static class PersistenceServicesRegisteration
	{
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddDbContext<MpMangementDbContext>(option =>
			{
				option.UseSqlServer(configuration.GetConnectionString("MpManagementConnection"));
			});

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
			services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
			services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
			return services;
		}
    }
}
