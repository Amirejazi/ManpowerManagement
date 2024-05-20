using AutoMapper;
using MediatR;
using MpManagement.Application.Exceptions;
using MpManagement.Application.Features.LeaveAllocations.Requests.Commands;
using MpManagement.Domain;
using MpManagement.Application.Contracts.Persistence;

namespace MpManagement.Application.Features.LeaveAllocations.Handlers.Commands
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
			if (leaveAllocation == null)
				throw new NotFoundException(nameof(LeaveAllocation), request.Id);

			await _leaveAllocationRepository.DeleteEntity(leaveAllocation);
			return Unit.Value;
		}
	}
}
