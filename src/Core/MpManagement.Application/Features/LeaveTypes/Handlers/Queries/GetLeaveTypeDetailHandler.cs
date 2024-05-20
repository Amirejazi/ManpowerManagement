using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MpManagement.Application.DTOs.LeaveType;
using MpManagement.Application.Features.LeaveTypes.Requests.Queries;
using MpManagement.Application.Contracts.Persistence;

namespace MpManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailHandler: IRequestHandler<GetLeaveTypeDetailRequest,LeaveTypeDTO>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public GetLeaveTypeDetailHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<LeaveTypeDTO> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
		{
			var leaveType = await _leaveTypeRepository.GetEntityBYId(request.Id);
			return _mapper.Map<LeaveTypeDTO>(leaveType); 
		}
	}
}
