using MediatR;
using RH.LeaveManagement.Application.DTOs.LeaveRequest;
using RH.LeaveManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand: IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto? LeaveRequestDto { get; set; }
    }
}
