using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MP_Management.Application.DTOs.LeaveType.Validators;
using MP_Management.Application.Features.LeaveTypes.Requests.Commands;
using MP_Management.Domain;
using MP_Management.Persistence.Contracts;

namespace MP_Management.Application.Features.LeaveTypes.Handlers.Commands
{
	public class CreateLeaveTypeCommandHandler: IRequestHandler<CreateLeaveTypeCommand,int>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new ILeaveTypeDtoValidator();
			var validation = await validator.ValidateAsync(request.CreateLeaveTypeDto);
			if (!validation.IsValid)
				throw new Exception();

			var newLeaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);
			await _leaveTypeRepository.AddEntity(newLeaveType);
			return newLeaveType.Id;
		}
	}
}
