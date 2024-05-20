using AutoMapper;
using MediatR;
using MpManagement.Application.DTOs.LeaveType;
using MpManagement.Application.Features.LeaveTypes.Requests.Queries;
using MpManagement.Application.Contracts.Persistence;

namespace MpManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListHandler: 
		IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDTO>>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public GetLeaveTypeListHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
		{
			var leaveTypeList = await _leaveTypeRepository.GetAllEntity();
			return _mapper.Map<List<LeaveTypeDTO>>(leaveTypeList);
		}
	}
}
