using FluentValidation;
using MP_Management.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Application.DTOs.LeaveAllocation.Validators
{
    public class CreateLeaveAllocationDtoValidator : AbstractValidator<CreateLeaveAllocationDTO>
    {
		private readonly ILeaveTypeRepository _leaveTypeRepository;

		public CreateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            Include(new LeaveAllocationDtoValidators(leaveTypeRepository));
        }
    }
}
