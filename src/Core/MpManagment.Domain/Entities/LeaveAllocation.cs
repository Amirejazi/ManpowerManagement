using MpManagement.Domain.Common;

namespace MpManagement.Domain
{
	public class LeaveAllocation: BaseDomainEntity
	{
		#region properties

		public int NumberOfDays { get; set; }
		public int LeaveTypeId { get; set; }
		public int Priod { get; set; }

		#endregion

		#region relatoins

		public LeaveType LeaveType { get; set; }

		#endregion

	}
}
