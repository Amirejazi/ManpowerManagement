using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MpManagement.Domain;

namespace MpManagement.Persistence.Configurations.Entities
{
	public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
	{
		public void Configure(EntityTypeBuilder<LeaveRequest> builder)
		{
			
		}
	}
}
