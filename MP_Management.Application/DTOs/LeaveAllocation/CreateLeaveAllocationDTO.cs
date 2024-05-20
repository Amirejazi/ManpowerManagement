using MP_Management.Application.DTOs.Common;

namespace MP_Management.Application.DTOs.LeaveAllocation
{
	public class CreateLeaveAllocationDTO
	{
		public int NumberOfDays { get; set; }
		public int LeaveTypeId { get; set; }
		public int Priod { get; set; }
	}
}
