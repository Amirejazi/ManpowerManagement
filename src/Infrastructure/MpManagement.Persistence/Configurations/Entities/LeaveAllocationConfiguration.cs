using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MpManagement.Domain;

namespace MpManagement.Persistence.Configurations.Entities
{
	public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
	{
		public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
		{
		}
	}
}
