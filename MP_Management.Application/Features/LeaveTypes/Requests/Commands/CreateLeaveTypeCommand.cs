using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MP_Management.Application.DTOs.LeaveRequest;
using MP_Management.Application.DTOs.LeaveType;

namespace MP_Management.Application.Features.LeaveTypes.Requests.Commands
{
	public class CreateLeaveTypeCommand: IRequest<int>
	{
		public CreateLeaveTypeDTO CreateLeaveTypeDto { get; set; }
	}
}
