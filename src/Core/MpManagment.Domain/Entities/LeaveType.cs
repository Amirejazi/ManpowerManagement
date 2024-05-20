using MpManagement.Domain.Common;

namespace MpManagement.Domain
{
	public class LeaveType: BaseDomainEntity
	{
		#region properties

		public string Name { get; set; }
		public int DefaultDay { get; set; }

		#endregion
	}
}
