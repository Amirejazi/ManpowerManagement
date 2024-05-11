using MediatR;
using MP_Management.Application.DTOs.LeaveRequest;

namespace MP_Management.Application.Features.LeaveRequests.Requests.Queries
{
	public class GetLeaveRequestDetailRequest: IRequest<LeaveRequestDTO>
	{
		public int Id { get; set; }
	}
}
