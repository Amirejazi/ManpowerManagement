using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveAllocation.Validators;
using MP_Management.Application.Exceptions;
using MP_Management.Application.Features.LeaveAllocations.Requests.Commands;
using MP_Management.Domain;
using MP_Management.Contracts.Persistence;
using MP_Management.Application.Responses;

namespace MP_Management.Application.Features.LeaveAllocations.Handlers.Commands
{
	public class CreateLeaveAllocationCommandHandler: IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
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

		public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();

			var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);
			if (!validationResult.IsValid)
			{
				// throw new ValidationException(validationResult);
				response.Success = false;
				response.Message = "Creation of LeaveAllocation Failed!";
				response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
				return response;
			}

			var newLeaveAllocation = _mapper.Map<LeaveAllocation>(request.CreateLeaveAllocationDto);
			await _leaveAllocationRepository.AddEntity(newLeaveAllocation);

			response.Success = true;
			response.Message = "Creation of LeaveAllocation Successed";
			response.Id = newLeaveAllocation.Id;
			return response;
		}
	}
}
