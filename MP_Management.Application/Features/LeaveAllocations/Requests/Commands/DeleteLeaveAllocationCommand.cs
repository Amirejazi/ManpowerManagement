using MediatR;

namespace MP_Management.Application.Features.LeaveAllocations.Requests.Commands
{
	public class DeleteLeaveAllocationCommand: IRequest<Unit>
	{
		public int Id { get; set; }
	}
}
