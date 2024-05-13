using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveAllocation;
using MP_Management.Application.Features.LeaveAllocations.Requests.Queries;
using MP_Management.Contracts.Persistence;

namespace MP_Management.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationDetailHandler: IRequestHandler<GetLeaveAllocationDetailRequest,LeaveAllocationDTO>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly IMapper _mapper;

		public GetLeaveAllocationDetailHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			_leaveAllocationRepository = leaveAllocationRepository;
			_mapper = mapper;
		}

		public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
		{
			var leaveAllocation = await _leaveAllocationRepository.GetEntityBYId(request.Id);
			return _mapper.Map<LeaveAllocationDTO>(leaveAllocation); 
		}
	}
}
