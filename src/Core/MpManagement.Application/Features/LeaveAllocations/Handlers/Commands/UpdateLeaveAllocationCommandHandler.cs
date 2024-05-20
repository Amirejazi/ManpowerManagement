using AutoMapper;
using MediatR;
using MpManagement.Application.DTOs.LeaveAllocation.Validators;
using MpManagement.Application.Exceptions;
using MpManagement.Application.Features.LeaveAllocations.Requests.Commands;
using MpManagement.Application.Contracts.Persistence;
using MpManagement.Domain;

namespace MpManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_leaveAllocationRepository = leaveAllocationRepository;
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
			var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request.UpdateLeaveAllocationDto);
			if (!validationResult.IsValid)
				throw new ValidationException(validationResult);

			var leaveAllocation = await _leaveAllocationRepository.GetEntityBYId(request.UpdateLeaveAllocationDto.Id);
			if (leaveAllocation == null)
				throw new NotFoundException(nameof(LeaveAllocation), request.UpdateLeaveAllocationDto.Id);

            _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation);
			await _leaveAllocationRepository.UpdateEntity(leaveAllocation);
            return Unit.Value;
        }
    }
}
