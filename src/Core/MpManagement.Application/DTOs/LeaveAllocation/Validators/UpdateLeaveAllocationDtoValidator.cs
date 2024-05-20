using FluentValidation;
using MpManagement.Application.DTOs.Common.Validators;
using MpManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpManagement.Application.DTOs.LeaveAllocation.Validators
{
	public class UpdateLeaveAllocationDtoValidator: AbstractValidator<UpdateLeaveAllocationDTO>
	{
		private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            Include(new LeaveAllocationDtoValidators(leaveTypeRepository));

        }
    }
}
