﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MpManagement.Application.DTOs.LeaveType;

namespace MpManagement.Application.Features.LeaveTypes.Requests.Commands
{
	public class UpdateLeaveTypeCommand: IRequest<Unit>
	{
		public UpdateLeaveTypeDTO UpdateLeaveTypeDto { get; set; }
	}
}
