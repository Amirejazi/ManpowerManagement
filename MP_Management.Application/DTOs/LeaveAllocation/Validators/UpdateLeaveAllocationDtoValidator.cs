using FluentValidation;
using MP_Management.Application.DTOs.Common.Validators;
using MP_Management.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Application.DTOs.LeaveAllocation.Validators
{
	public class UpdateLeaveAllocationDtoValidator: AbstractValidator<UpdateLeaveAllocationDTO>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            Include(new BaseDtoValidator());
            Include(new LeaveAllocationDtoValidators(leaveTypeRepository));
        }
    }
}
