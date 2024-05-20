using MpManagement.Domain;

namespace MpManagement.Application.Contracts.Persistence
{
	public interface ILeaveRequestRepository: IGenericRepository<LeaveRequest>
	{
		Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
		Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
		Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
	}
}
