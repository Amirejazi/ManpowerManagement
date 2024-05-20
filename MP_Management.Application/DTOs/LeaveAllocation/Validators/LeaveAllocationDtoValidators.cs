﻿using FluentValidation;
using MP_Management.Application.DTOs.Common.Validators;
using MP_Management.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Application.DTOs.LeaveAllocation.Validators
{
	public class LeaveAllocationDtoValidators: AbstractValidator<LeaveAllocationDTO>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveAllocationDtoValidators(ILeaveTypeRepository leaveTypeRepository)
        {
			_leaveTypeRepository = leaveTypeRepository;

			Include(new BaseDtoValidator());

			RuleFor(p => p.NumberOfDays).GreaterThan(0).WithMessage("{PropertyName} greater than {ComparisonValue}");
            RuleFor(p => p.Priod).GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must be after {ComparisonValue}");
			RuleFor(p => p.LeaveTypeId)
				.GreaterThan(0)
			.MustAsync(async (id, token) =>
			{
					var leaveTypeExist = await _leaveTypeRepository.ExistEntity(id);
					return leaveTypeExist;
				})
				.WithMessage("{PropertyName} does not exist");
		}
    }
}
