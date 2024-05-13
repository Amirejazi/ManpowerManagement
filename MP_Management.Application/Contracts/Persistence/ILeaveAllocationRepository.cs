using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MP_Management.Domain;

namespace MP_Management.Contracts.Persistence
{
	public interface ILeaveAllocationRepository: IGenericRepository<LeaveAllocation>
	{
		Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
		Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
	}
}
