using Microsoft.EntityFrameworkCore;
using MP_Management.Domain;
using MP_Management.Domain.Common;

namespace MP_Management.Persistence.Context
{
	public class MP_MangementDbContext : DbContext
	{
		public MP_MangementDbContext(DbContextOptions<MP_MangementDbContext> option) : base(option)
		{
		}

		public DbSet<LeaveType> LeaveTypes { get; set; }
		public DbSet<LeaveRequest> LeaveRequests { get; set; }
		public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MP_MangementDbContext).Assembly);
		}

		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
				entry.Entity.LastModifiedDate = DateTime.Now;

				if(entry.State == EntityState.Added) 
				{
					entry.Entity.CreatedDate = DateTime.Now;
				}
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}

		public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
			{
				entry.Entity.LastModifiedDate = DateTime.Now;

				if (entry.State == EntityState.Added)
				{
					entry.Entity.CreatedDate = DateTime.Now;
				}
			}

			return base.SaveChanges();
		}
	}
}
