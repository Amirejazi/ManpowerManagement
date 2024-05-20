﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MP_Management.Application.DTOs.LeaveRequest;

namespace MP_Management.Application.Features.LeaveRequests.Requests.Commands
{
	public class UpdateLeaveRequestCommand: IRequest<Unit>
	{
		public UpdateLeaveRequestDTO UpdateLeaveRequestDto { get; set; }
	}
}
