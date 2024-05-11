using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Application.DTOs.LeaveType.Validators
{
	public class UpdateLeaveTypeDtoValidator: AbstractValidator<UpdateLeaveTypeDTO>
	{
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
