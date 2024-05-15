using FluentValidation;
using MP_Management.Application.DTOs.Common.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Application.DTOs.LeaveRequest.Validators
{
	public class ChangeLeaveRequestApprovalDtoValidator: AbstractValidator<ChangeLeaveRequestApprovalDTO>
	{
        public ChangeLeaveRequestApprovalDtoValidator()
        {
			Include(new BaseDtoValidator());

			RuleFor(p => p.Approved).NotNull().WithMessage("{PropertyName} is required.");
		}

    }
}
