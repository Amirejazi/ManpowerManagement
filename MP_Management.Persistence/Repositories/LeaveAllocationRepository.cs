using Microsoft.EntityFrameworkCore;
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
	public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
	{
		public LeaveAllocationRepository(MP_MangementDbContext context) : base(context)
		{
		}

		public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
		{
			var leaveAllocations = await GetQuery().Include(l => l.LeaveType).ToListAsync();
			return leaveAllocations;
		}

		public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
		{
			var leaveAllocation = await GetQuery().Include(l => l.LeaveType).FirstOrDefaultAsync(l => l.Id == id);
			return leaveAllocation;
		}
	}
}
