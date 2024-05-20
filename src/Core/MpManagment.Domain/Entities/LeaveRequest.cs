using MpManagement.Domain.Common;

namespace MpManagement.Domain
{
	public class LeaveRequest: BaseDomainEntity
	{
		#region properties

		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int LeaveTypeId { get; set; }
		public DateTime DateRequest { get; set; }
		public string RequestComment { get; set; }
		public DateTime? DateActioned { get; set; }
		public bool Aproved { get; set; }
		public bool Canceled { get; set; }

		#endregion

		#region relations

		public LeaveType LeaveType { get; set; }

		#endregion
	}
}
