using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace MP_Management.Application.DTOs.LeaveType.Validators
{
	public class CreateLeaveTypeDtoValidator: AbstractValidator<CreateLeaveTypeDTO>
	{
		public CreateLeaveTypeDtoValidator()
		{
			Include(new ILeaveTypeDtoValidator());
		}
	}
}
