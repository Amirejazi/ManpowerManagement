﻿using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveAllocation.Validators;
using MP_Management.Application.Features.LeaveAllocations.Requests.Commands;
using MP_Management.Persistence.Contracts;

namespace MP_Management.Application.Features.LeaveAllocations.Handlers.Commands
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
			var validation = await validator.ValidateAsync(request.UpdateLeaveAllocationDto);
			if (!validation.IsValid)
				throw new Exception();

			var leaveAllocation = await _leaveAllocationRepository.GetEntityBYId(request.UpdateLeaveAllocationDto.Id);
            _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation);
            _leaveAllocationRepository.UpdateEntity(leaveAllocation);
            return Unit.Value;
        }
    }
}
