﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MP_Management.Application.DTOs.Common;

namespace MP_Management.Application.DTOs.LeaveRequest
{
	public class CreateLeaveRequestDTO
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int LeaveTypeId { get; set; }
		public DateTime DateRequest { get; set; }
		public string RequestComment { get; set; }
	}
}
