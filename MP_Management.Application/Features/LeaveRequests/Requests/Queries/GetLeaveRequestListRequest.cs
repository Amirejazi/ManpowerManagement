using MediatR;
using MP_Management.Application.DTOs.LeaveRequest;

namespace MP_Management.Application.Features.LeaveRequests.Requests.Queries
{
	public class GetLeaveRequestListRequest: IRequest<List<LeaveRequestDTO>>
	{

	}
}
