﻿using FluentValidation;
using MP_Management.Application.DTOs.Common.Validators;
using MP_Management.Persistence.Contracts;
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

			Include(new BaseDtoValidator());

			RuleFor(p => p.StartDate)
				.LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");
			RuleFor(p => p.EndDate)
				.GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");
			RuleFor(p => p.LeaveTypeId)
				.GreaterThan(0)
				.MustAsync(async (id, token) =>
				{
					var leaveTypeExist = await _leaveTypeRepository.ExistEntity(id);
					return !leaveTypeExist;
				})
				.WithMessage("{PropertyName} does not exist");
		}
    }
}
