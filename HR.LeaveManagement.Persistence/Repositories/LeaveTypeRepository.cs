using HR.LeaveManagement.Domain;
using RH.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagamentDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagamentDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
