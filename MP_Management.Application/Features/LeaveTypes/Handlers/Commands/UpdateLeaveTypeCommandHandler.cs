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
	public class UpdateLeaveTypeCommandHandler: IRequestHandler<UpdateLeaveTypeCommand, Unit>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;
		private readonly IMapper _mapper;

		public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
		{
			_leaveTypeRepository = leaveTypeRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
		{
			var validator = new ILeaveTypeDtoValidator();
			var validation = await validator.ValidateAsync(request.UpdateLeaveTypeDto);
			if (!validation.IsValid)
				throw new Exception();

			var leaveType = await _leaveTypeRepository.GetEntityBYId(request.UpdateLeaveTypeDto.Id);
			_mapper.Map(request.UpdateLeaveTypeDto, leaveType);
			_leaveTypeRepository.UpdateEntity(leaveType);
			return Unit.Value;
		}
	}
}
