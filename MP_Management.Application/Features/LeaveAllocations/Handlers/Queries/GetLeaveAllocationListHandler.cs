using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveAllocation;
using MP_Management.Application.Features.LeaveAllocations.Requests.Queries;
using MP_Management.Contracts.Persistence;

namespace MP_Management.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListHandler: 
		IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDTO>>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly IMapper _mapper;

		public GetLeaveAllocationListHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			_leaveAllocationRepository = leaveAllocationRepository;
			_mapper = mapper;
		}

		public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationListRequest Request, CancellationToken cancellationToken)
		{
			var leaveAllocationList = await _leaveAllocationRepository.GetAllEntity();
			return _mapper.Map<List<LeaveAllocationDTO>>(leaveAllocationList);
		}
	}
}
