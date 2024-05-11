using MediatR;
using MP_Management.Application.DTOs.LeaveType;

namespace MP_Management.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequest: IRequest<LeaveTypeDTO>
	{
		public int Id { get; set; }
	}
}
