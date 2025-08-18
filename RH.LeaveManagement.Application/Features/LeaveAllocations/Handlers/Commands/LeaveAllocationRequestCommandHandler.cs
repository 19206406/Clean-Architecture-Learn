using AutoMapper;
using HR.LeaveManagement.Domain;
using MediatR;
using RH.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using RH.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class LeaveAllocationRequestCommandHandler : IRequestHandler<LeaveAllocationRequestCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public LeaveAllocationRequestCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(LeaveAllocationRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);

            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation); 

            return leaveAllocation.Id;
        }
    }
}
