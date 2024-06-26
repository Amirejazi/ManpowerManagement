﻿using AutoMapper;
using MediatR;
using MpManagement.Application.DTOs.LeaveRequest.Validators;
using MpManagement.Application.Features.LeaveRequests.Requests.Commands;
using MpManagement.Domain;
using MpManagement.Application.Contracts.Persistence;
using MpManagement.Application.Contracts.Infrastructure;
using MpManagement.Application.Models;
using MpManagement.Application.Exceptions;

namespace MpManagement.Application.Features.LeaveRequests.Handlers.Commands
{
	public class CreateLeaveRequestCommandHandler: IRequestHandler<CreateLeaveRequestCommand,int>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;
		private readonly IEmailSender _emailSender;

		public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
			ILeaveTypeRepository leaveTypeRepository,
			IMapper mapper,
			IEmailSender emailSender)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
			_emailSender = emailSender;
		}

		public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
			var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);
			if (!validationResult.IsValid)
				throw new ValidationException(validationResult);

			var newLeaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);
			await _leaveRequestRepository.AddEntity(newLeaveRequest);

			//var email = new Email
			//{
			//	To = "ejaziamirhosein@gmail.com",
			//	Subject="leave request submitted",
			//	Body=$"Your leave request for {request.CreateLeaveRequestDto.StartDate} to {request.CreateLeaveRequestDto.EndDate}"+
			//	"has been submitted"
			//};
			//try
			//{
			//	await _emailSender.SendEmail(email);
			//}
			//catch (Exception ex)
			//{
			//	// log
			//}
			return newLeaveRequest.Id;
		}
	}
}
