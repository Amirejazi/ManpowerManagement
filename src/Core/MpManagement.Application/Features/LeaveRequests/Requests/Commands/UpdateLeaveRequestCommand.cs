using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MpManagement.Application.DTOs.LeaveRequest;

namespace MpManagement.Application.Features.LeaveRequests.Requests.Commands
{
	public class UpdateLeaveRequestCommand: IRequest<Unit>
	{
		public UpdateLeaveRequestDTO UpdateLeaveRequestDto { get; set; }
	}
}
