using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveRequest;
using MP_Management.Application.Features.LeaveRequests.Requests.Queries;
using MP_Management.Contracts.Persistence;

namespace MP_Management.Application.Features.LeaveRequests.Handlers.Queries
{
	public class GetLeaveRequestDetailHandler: IRequestHandler<GetLeaveRequestDetailRequest,LeaveRequestDTO>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly IMapper _mapper;

		public GetLeaveRequestDetailHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_mapper = mapper;
		}

		public async Task<LeaveRequestDTO> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _leaveRequestRepository.GetEntityBYId(request.Id);
			return _mapper.Map<LeaveRequestDTO>(leaveRequest);
		}
	}
}
