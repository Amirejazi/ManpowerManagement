﻿using MpManagement.Application.DTOs.Common;

namespace MpManagement.Application.DTOs.LeaveAllocation
{
	public class CreateLeaveAllocationDTO
	{
		public int NumberOfDays { get; set; }
		public int LeaveTypeId { get; set; }
		public int Priod { get; set; }
	}
}
