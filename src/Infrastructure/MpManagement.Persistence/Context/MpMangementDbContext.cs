using Microsoft.EntityFrameworkCore;
using MpManagement.Domain;
using MpManagement.Domain.Common;

namespace MpManagement.Persistence.Context
{
	public class MpMangementDbContext : DbContext
	{
		public MpMangementDbContext(DbContextOptions<MpMangementDbContext> option) : base(option)
		{
		}

		public DbSet<LeaveType> LeaveTypes { get; set; }
		public DbSet<LeaveRequest> LeaveRequests { get; set; }
		public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MpMangementDbContext).Assembly);
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
