using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveType;
using MP_Management.Application.Features.LeaveTypes.Requests.Queries;
using MP_Management.Persistence.Contracts;

namespace MP_Management.Application.Features.LeaveTypes.Handlers.Queries
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
