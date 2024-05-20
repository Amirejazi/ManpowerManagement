using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveRequest.Validators;
using MP_Management.Application.Exceptions;
using MP_Management.Application.Features.LeaveRequests.Requests.Commands;
using MP_Management.Contracts.Persistence;

namespace MP_Management.Application.Features.LeaveRequests.Handlers.Commands
{
	public class UpdateLeaveRequestCommandHandler:IRequestHandler<UpdateLeaveRequestCommand, Unit>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request.UpdateLeaveRequestDto);
			if (!validationResult.IsValid)
				throw new ValidationException(validationResult);

			var leaveRequest = await _leaveRequestRepository.GetEntityBYId(request.UpdateLeaveRequestDto.Id);
			_mapper.Map(request.UpdateLeaveRequestDto, leaveRequest);
			await _leaveRequestRepository.UpdateEntity(leaveRequest);
			
			return Unit.Value;
		}
	}
}
