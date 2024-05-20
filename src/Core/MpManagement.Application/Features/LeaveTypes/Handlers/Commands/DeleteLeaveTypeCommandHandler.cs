using AutoMapper;
using MediatR;
using MpManagement.Application.Exceptions;
using MpManagement.Application.Features.LeaveTypes.Requests;
using MpManagement.Domain;
using MpManagement.Application.Contracts.Persistence;

namespace MpManagement.Application.Features.LeaveTypes.Handlers.Commands
{
	public class DeleteLeaveTypeCommandHandler: IRequestHandler<DeleteLeaveTypeCommand,Unit>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var leaveType = await _leaveTypeRepository.GetEntityBYId(request.Id);
			if(leaveType == null)
				throw new NotFoundException(nameof(LeaveType), request.Id);

			await _leaveTypeRepository.DeleteEntity(leaveType);

			return Unit.Value;
		}
	}
}
