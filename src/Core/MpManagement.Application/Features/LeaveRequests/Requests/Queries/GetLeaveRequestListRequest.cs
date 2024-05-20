using MediatR;
using MpManagement.Application.DTOs.LeaveRequest;

namespace MpManagement.Application.Features.LeaveRequests.Requests.Queries
{
	public class GetLeaveRequestListRequest: IRequest<List<LeaveRequestDTO>>
	{

	}
}
