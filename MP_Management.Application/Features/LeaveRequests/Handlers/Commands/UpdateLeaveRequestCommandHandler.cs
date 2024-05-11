﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveRequest.Validators;
using MP_Management.Application.Features.LeaveRequests.Requests.Commands;
using MP_Management.Persistence.Contracts;

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
			var validation = await validator.ValidateAsync(request.UpdateLeaveRequestDto);
			if (!validation.IsValid)
				throw new Exception();

			var leaveRequest = await _leaveRequestRepository.GetEntityBYId(request.Id);
			if (request.UpdateLeaveRequestDto != null)
			{
				_mapper.Map(request.UpdateLeaveRequestDto, leaveRequest);
				_leaveRequestRepository.UpdateEntity(leaveRequest);
			}
			else if (request.ChangeLeaveRequestApprovalDto != null)
			{
				await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest,  request.ChangeLeaveRequestApprovalDto.Approved);
			}
			
			return Unit.Value;
		}
	}
}
