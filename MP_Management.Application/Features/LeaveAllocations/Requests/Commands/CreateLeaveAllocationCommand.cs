using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MP_Management.Application.DTOs.LeaveAllocation;

namespace MP_Management.Application.Features.LeaveAllocations.Requests.Commands
{
	public class CreateLeaveAllocationCommand: IRequest<int>
	{
		public CreateLeaveAllocationDTO CreateLeaveAllocationDto { get; set; }
	}
}
