using MP_Management.Domain;
using MP_Management.Persistence.Context;
using MP_Management.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Persistence.Repositories
{
	public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
	{
		public LeaveTypeRepository(MP_MangementDbContext context) : base(context)
		{
		}
	}
}
