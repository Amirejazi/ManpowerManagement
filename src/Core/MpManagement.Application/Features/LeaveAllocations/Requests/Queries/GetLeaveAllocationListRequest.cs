using MediatR;
using MpManagement.Application.DTOs.LeaveAllocation;

namespace MpManagement.Application.Features.LeaveAllocations.Requests.Queries
{

    public class GetLeaveAllocationListRequest: IRequest<List<LeaveAllocationDTO>>
	{

	}
}
