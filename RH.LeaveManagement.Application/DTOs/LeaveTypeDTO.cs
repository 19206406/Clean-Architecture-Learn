using RH.LeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.LeaveManagement.Application.DTOs
{
    public class LeaveTypeDTO: BaseDTO
    {
        public string? Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
