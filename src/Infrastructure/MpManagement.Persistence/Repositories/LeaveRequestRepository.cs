using Microsoft.EntityFrameworkCore;
using MpManagement.Application.Contracts.Persistence;
using MpManagement.Domain;
using MpManagement.Persistence.Context;

namespace MpManagement.Persistence.Repositories
{
	public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
	{
		public LeaveRequestRepository(MpMangementDbContext context) : base(context)
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
