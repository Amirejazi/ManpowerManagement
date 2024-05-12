using AutoMapper;
using MediatR;
using MP_Management.Application.Exceptions;
using MP_Management.Application.Features.LeaveTypes.Requests;
using MP_Management.Domain;
using MP_Management.Persistence.Contracts;

namespace MP_Management.Application.Features.LeaveTypes.Handlers.Commands
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
