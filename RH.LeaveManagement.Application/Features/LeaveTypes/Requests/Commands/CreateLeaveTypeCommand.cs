using MediatR;
using RH.LeaveManagement.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands
{
    // el id representa el id del detalle de tipo de licencia que se crea
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public CreateLeaveTypeDto? CreateLeaveTypeDto { get; set; }
    }
}
