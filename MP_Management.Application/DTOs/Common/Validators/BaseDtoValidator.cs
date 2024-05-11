using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Application.DTOs.Common.Validators
{
	public class BaseDtoValidator: AbstractValidator<BaseDTO>
	{
        public BaseDtoValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
