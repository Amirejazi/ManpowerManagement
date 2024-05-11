﻿using MP_Management.Domain;

namespace MP_Management.Persistence.Contracts
{
	public interface ILeaveRequestRepository: IGenericRepository<LeaveRequest>
	{
		Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
	}
}
