﻿using AutoMapper;
using MediatR;
using MpManagement.Application.DTOs.LeaveType.Validators;
using MpManagement.Application.Exceptions;
using MpManagement.Application.Features.LeaveTypes.Requests.Commands;
using MpManagement.Application.Responses;
using MpManagement.Domain;
using MpManagement.Application.Contracts.Persistence;

namespace MpManagement.Application.Features.LeaveTypes.Handlers.Commands
{
	public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new ILeaveTypeDtoValidator();
			var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDto);
			if (!validationResult.IsValid)
			{
				response.Success = false;
				response.Message = "Creation Failed!";
				response.Errors = validationResult.Errors.Select(v => v.ErrorMessage).ToList();
				return response;
			}

			var newLeaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);
			await _leaveTypeRepository.AddEntity(newLeaveType);
			response.Success = true;
			response.Message = "Creation Success!";
			response.Id = newLeaveType.Id;

			return response;
		}
	}
}
