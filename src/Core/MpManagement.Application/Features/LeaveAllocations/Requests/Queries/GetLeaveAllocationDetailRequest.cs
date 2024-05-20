using MediatR;
using MpManagement.Application.DTOs.LeaveAllocation;

namespace MpManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest: IRequest<LeaveAllocationDTO>
	{
		public int Id { get; set; }
	}
}
