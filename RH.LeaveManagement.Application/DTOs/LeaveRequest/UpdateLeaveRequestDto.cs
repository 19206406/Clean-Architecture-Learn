using RH.LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.LeaveManagement.Application.DTOs.LeaveRequest
{
    public class UpdateLeaveRequestDto: BaseDto, ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string? RequestComments { get; set; }
        public bool Cancelled { get; set; }

        // Additional properties can be added here if needed
        // For example, you might want to include a property for the employee ID
        // public int EmployeeId { get; set; }
    }
}
