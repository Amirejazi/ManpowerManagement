using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MpManagement.Domain;

namespace MpManagement.Persistence.Configurations.Entities
{
	public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
	{
		public void Configure(EntityTypeBuilder<LeaveType> builder)
		{
			builder.HasData(
				new LeaveType
				{
					Id = 1,
					DefaultDay = 10,
					Name = "Vacatoin",
				},
				new LeaveType
				{
					Id = 2,
					DefaultDay = 14,
					Name = "Sick",
				}
				);
		}
	}
}
