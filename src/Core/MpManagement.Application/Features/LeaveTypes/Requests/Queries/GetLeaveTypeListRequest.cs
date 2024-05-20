using MediatR;
using MpManagement.Application.DTOs.LeaveType;

namespace MpManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDTO>>
	{

	}
}
