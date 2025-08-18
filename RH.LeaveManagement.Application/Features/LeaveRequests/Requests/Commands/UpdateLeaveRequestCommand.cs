using MediatR;
using RH.LeaveManagement.Application.DTOs.LeaveRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public LeaveRequestDto? leaveRequestsDto { get; set; }
        public ChangeLeaveRequestApprovalDto? ChangeLeaveRequestApprovalDto { get; set; }
    }
}
