using FluentValidation;
using MpManagement.Application.DTOs.Common.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpManagement.Application.DTOs.LeaveRequest.Validators
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
