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
	public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
	{
		public LeaveRequestRepository(MP_MangementDbContext context) : base(context)
		{
		}

		public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
		{
			leaveRequest.Aproved = (bool) approvalStatus;
			await UpdateEntity(leaveRequest);
		}

		public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
		{
			var leaveRequests = await GetQuery().Include(l => l.LeaveType).ToListAsync();
			return leaveRequests;
		}

		public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
		{
			var leaveRequest = await GetQuery().Include(l => l.LeaveType).FirstOrDefaultAsync(l => l.Id == id);
			return leaveRequest;
		}
	}
}
