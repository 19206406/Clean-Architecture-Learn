using AutoMapper;
using MediatR;
using RH.LeaveManagement.Application.Exceptions;
using RH.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using RH.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        // esto taca que dejarlo así por que estaba generando error por el unit 
        // por eso en el command lo dejamos como Unit para que no genere error
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveRequestRepository.Get(request.Id);

            if (leaveType is null)
                throw new NotFoundException(nameof(leaveType), request.Id); 

            await _leaveRequestRepository.Delete(leaveType);

            return Unit.Value;
        }

    }
}
