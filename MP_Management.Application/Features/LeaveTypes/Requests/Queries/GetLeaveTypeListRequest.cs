using MediatR;
using MP_Management.Application.DTOs.LeaveType;

namespace MP_Management.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDTO>>
	{

	}
}
