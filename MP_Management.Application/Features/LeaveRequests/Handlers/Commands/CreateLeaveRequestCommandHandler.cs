using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveRequest.Validators;
using MP_Management.Application.DTOs.LeaveType.Validators;
using MP_Management.Application.Features.LeaveRequests.Requests.Commands;
using MP_Management.Domain;
using MP_Management.Persistence.Contracts;

namespace MP_Management.Application.Features.LeaveRequests.Handlers.Commands
{
	public class CreateLeaveRequestCommandHandler: IRequestHandler<CreateLeaveRequestCommand,int>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
			var validation = await validator.ValidateAsync(request.CreateLeaveRequestDto);
			if (!validation.IsValid)
				throw new Exception();

			var newLeaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);
			await _leaveRequestRepository.AddEntity(newLeaveRequest);
			return newLeaveRequest.Id;
		}
	}
}
