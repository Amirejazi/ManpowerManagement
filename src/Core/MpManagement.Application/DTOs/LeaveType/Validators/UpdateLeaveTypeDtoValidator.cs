using FluentValidation;
using MpManagement.Application.DTOs.Common;
using MpManagement.Application.DTOs.Common.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpManagement.Application.DTOs.LeaveType.Validators
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
