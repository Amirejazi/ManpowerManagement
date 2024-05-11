using MediatR;
using MP_Management.Application.DTOs.LeaveAllocation;

namespace MP_Management.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest: IRequest<LeaveAllocationDTO>
	{
		public int Id { get; set; }
	}
}
