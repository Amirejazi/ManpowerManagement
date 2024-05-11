using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MP_Management.Application.Features.LeaveAllocations.Requests.Commands;
using MP_Management.Persistence.Contracts;

namespace MP_Management.Application.Features.LeaveAllocations.Handlers.Commands
{
	public class DeleteLeaveAllocationCommandHandler: IRequestHandler<DeleteLeaveAllocationCommand, Unit>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly IMapper _mapper;

		public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
		{
			_leaveAllocationRepository = leaveAllocationRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var leaveAllocation = await _leaveAllocationRepository.GetEntityBYId(request.Id);
			await _leaveAllocationRepository.DeleteEntity(leaveAllocation);
			return Unit.Value;
		}
	}
}
