using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MpManagement.Application.DTOs.LeaveRequest;
using MpManagement.Application.DTOs.LeaveType;
using MpManagement.Application.Responses;

namespace MpManagement.Application.Features.LeaveTypes.Requests.Commands
{
	public class CreateLeaveTypeCommand: IRequest<BaseCommandResponse>
	{
		public CreateLeaveTypeDTO CreateLeaveTypeDto { get; set; }
	}
}
