using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveRequest;
using MP_Management.Application.Features.LeaveRequests.Requests.Queries;
using MP_Management.Persistence.Contracts;

namespace MP_Management.Application.Features.LeaveRequests.Handlers.Queries
{
	public class GetLeaveRequestListHandler: 
		IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestDTO>>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly IMapper _mapper;

		public GetLeaveRequestListHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_mapper = mapper;
		}

		public async Task<List<LeaveRequestDTO>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
		{
			var leaveRequestList = await _leaveRequestRepository.GetAllEntity();
			return _mapper.Map<List<LeaveRequestDTO>>(leaveRequestList);
		}
	}
}
