using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparasonValue} characters"); 

            RuleFor(x => x.DefaultDays) 
                .NotEmpty().WithMessage("{PropertyName} is required.").
                GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
        }
    }
}
