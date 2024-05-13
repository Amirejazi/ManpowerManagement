using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP_Management.Persistence.Context;
using MP_Management.Contracts.Persistence;
using MP_Management.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Persistence
{
	public static class PersistenceServicesRegisteration
	{
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddDbContext<MP_MangementDbContext>(option =>
			{
				option.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
			});

			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
			services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
			services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
			return services;
		}
    }
}
