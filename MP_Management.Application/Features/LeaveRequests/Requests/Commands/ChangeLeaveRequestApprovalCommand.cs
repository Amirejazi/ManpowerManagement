using MediatR;
using MP_Management.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Application.Features.LeaveRequests.Requests.Commands
{
	public class ChangeLeaveRequestApprovalCommand: IRequest<int>
	{
        public ChangeLeaveRequestApprovalDTO ChangeLeaveRequestApprovalDto { get; set; }
    }
}
