using MediatR;
using RH.LeaveManagement.Application.DTOs.LeaveAllocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands
{
    public class LeaveAllocationRequestCommand : IRequest<int>
    {
        public LeaveAllocationDto? LeaveAllocationDto { get; set; }
    }
}
