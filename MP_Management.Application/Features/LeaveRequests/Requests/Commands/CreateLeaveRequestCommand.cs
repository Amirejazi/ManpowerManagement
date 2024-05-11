using MediatR;
using MP_Management.Application.DTOs.LeaveRequest;

namespace MP_Management.Application.Features.LeaveRequests.Requests.Commands
{
	public class CreateLeaveRequestCommand: IRequest<int>
	{
		public CreateLeaveRequestDTO CreateLeaveRequestDto { get; set; }
	}
}
