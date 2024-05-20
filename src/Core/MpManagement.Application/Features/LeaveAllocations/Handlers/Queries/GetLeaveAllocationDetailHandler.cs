using AutoMapper;
using MediatR;
using MpManagement.Application.DTOs.LeaveAllocation;
using MpManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MpManagement.Application.Contracts.Persistence;

namespace MpManagement.Application.Features.LeaveAllocations.Handlers.Queries
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
