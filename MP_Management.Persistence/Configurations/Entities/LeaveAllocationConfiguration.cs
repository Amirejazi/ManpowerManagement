using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP_Management.Domain;

namespace MP_Management.Persistence.Configurations.Entities
{
	public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
	{
		public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
		{
		}
	}
}
