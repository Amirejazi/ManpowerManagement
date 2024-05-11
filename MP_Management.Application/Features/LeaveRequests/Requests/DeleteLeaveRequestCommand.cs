﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MP_Management.Application.Features.LeaveRequests.Requests
{
	public class DeleteLeaveRequestCommand: IRequest
	{
		public int Id { get; set; }
	}
}
