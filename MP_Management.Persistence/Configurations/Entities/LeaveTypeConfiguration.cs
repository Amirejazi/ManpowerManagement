using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP_Management.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Persistence.Configurations.Entities
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
