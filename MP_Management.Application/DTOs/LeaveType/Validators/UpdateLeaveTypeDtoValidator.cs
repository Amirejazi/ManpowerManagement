using FluentValidation;
using MP_Management.Application.DTOs.Common;
using MP_Management.Application.DTOs.Common.Validators;
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

            Include(new BaseDtoValidator());
        }
    }
}
