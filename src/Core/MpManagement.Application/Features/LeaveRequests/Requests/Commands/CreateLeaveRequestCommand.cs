using MediatR;
using MpManagement.Application.DTOs.LeaveRequest;

namespace MpManagement.Application.Features.LeaveRequests.Requests.Commands
{
	public class CreateLeaveRequestCommand: IRequest<int>
	{
		public CreateLeaveRequestDTO CreateLeaveRequestDto { get; set; }
	}
}
