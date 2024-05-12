using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveAllocation.Validators;
using MP_Management.Application.Exceptions;
using MP_Management.Application.Features.LeaveAllocations.Requests.Commands;
using MP_Management.Domain;
using MP_Management.Persistence.Contracts;

namespace MP_Management.Application.Features.LeaveAllocations.Handlers.Commands
{
	public class CreateLeaveAllocationCommandHandler: IRequestHandler<CreateLeaveAllocationCommand,int>
	{
		private readonly ILeaveAllocationRepository _leaveAllocationRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_leaveAllocationRepository = leaveAllocationRepository;
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);
			if (!validationResult.IsValid)
				throw new ValidationException(validationResult);

			var newLeaveAllocation = _mapper.Map<LeaveAllocation>(request.CreateLeaveAllocationDto);
			await _leaveAllocationRepository.AddEntity(newLeaveAllocation);
			return newLeaveAllocation.Id;
		}
	}
}
