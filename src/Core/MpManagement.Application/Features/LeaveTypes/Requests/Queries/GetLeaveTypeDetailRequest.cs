using MediatR;
using MpManagement.Application.DTOs.LeaveType;

namespace MpManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequest: IRequest<LeaveTypeDTO>
	{
		public int Id { get; set; }
	}
}
