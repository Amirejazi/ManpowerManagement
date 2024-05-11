using MP_Management.Domain.Common;

namespace MP_Management.Domain
{
	public class LeaveRequest: BaseDomainEntity
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public LeaveType LeaveType { get; set; }
		public int LeaveTypeId { get; set; }
		public DateTime DateRequest { get; set; }
		public string RequestComment { get; set; }
		public DateTime? DateActioned { get; set; }
		public bool Aproved { get; set; }
		public bool Canceled { get; set; }
	}
}
