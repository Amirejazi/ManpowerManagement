using Microsoft.EntityFrameworkCore;
using MpManagement.Application.Contracts.Persistence;
using MpManagement.Domain;
using MpManagement.Persistence.Context;

namespace MpManagement.Persistence.Repositories
{
	public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
	{
		public LeaveAllocationRepository(MpMangementDbContext context) : base(context)
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
