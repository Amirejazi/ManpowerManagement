﻿using FluentValidation;
using MpManagement.Application.Contracts.Persistence;

namespace MpManagement.Application.DTOs.LeaveRequest.Validators
{
	public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDTO>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
			_leaveTypeRepository = leaveTypeRepository;

			RuleFor(p => p.StartDate)
				.LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");
			RuleFor(p => p.EndDate)
				.GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");
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
