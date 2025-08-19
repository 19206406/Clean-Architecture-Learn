using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            // Con esto nos traemos las validaciones de ILeaveTypeDtoValidator 
            // y las aplicamos a CreateLeaveTypeDto
            Include(new ILeaveTypeDtoValidator());  
        }
    }
}
