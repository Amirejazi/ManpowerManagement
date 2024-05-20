using MpManagement.Domain;

namespace MpManagement.Application.Contracts.Persistence
{
	public interface ILeaveAllocationRepository: IGenericRepository<LeaveAllocation>
	{
		Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
		Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
	}
}
