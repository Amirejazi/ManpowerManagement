using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MpManagement.Application.DTOs.LeaveAllocation;
using MpManagement.Application.Responses;

namespace MpManagement.Application.Features.LeaveAllocations.Requests.Commands
{
	public class CreateLeaveAllocationCommand: IRequest<BaseCommandResponse>
	{
		public CreateLeaveAllocationDTO CreateLeaveAllocationDto { get; set; }
	}
}
