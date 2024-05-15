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
	public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
	{
		public void Configure(EntityTypeBuilder<LeaveRequest> builder)
		{
			
		}
	}
}
