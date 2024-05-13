using MP_Management.Domain;

namespace MP_Management.Contracts.Persistence
{
	public interface ILeaveRequestRepository: IGenericRepository<LeaveRequest>
	{
		Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
		Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
		Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
	}
}
