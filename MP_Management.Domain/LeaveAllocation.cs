﻿using MP_Management.Domain.Common;

namespace MP_Management.Domain
{
	public class LeaveAllocation: BaseDomainEntity
	{
		public int NumberOfDays { get; set; }
		public LeaveType LeaveType { get; set; }
		public int LeaveTypeId { get; set; }
		public int Priod { get; set; }
	}
}
