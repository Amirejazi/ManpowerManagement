using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MpManagement.Application.DTOs.LeaveAllocation;

namespace MpManagement.Application.Features.LeaveAllocations.Requests.Commands
{
	public class UpdateLeaveAllocationCommand: IRequest<Unit>
	{
		public UpdateLeaveAllocationDTO UpdateLeaveAllocationDto { get; set; }

	}
}
