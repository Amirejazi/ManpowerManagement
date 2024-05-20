using FluentValidation;
using MP_Management.Application.DTOs.Common.Validators;
using MP_Management.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Application.DTOs.LeaveRequest.Validators
{
	public class UpdateLeaveRequestDtoValidator: AbstractValidator<UpdateLeaveRequestDTO>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public UpdateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
			_leaveTypeRepository = leaveTypeRepository;

			Include(new CreateLeaveRequestDtoValidator(_leaveTypeRepository));

			RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is required.");
			RuleFor(p => p.Canceled).NotNull().WithMessage("{PropertyName} is required.");

		}
	}
}