using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using MediatR;
using RH.LeaveManagement.Application.Exceptions;
using RH.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using RH.LeaveManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = RH.LeaveManagement.Application.Exceptions.ValidationException;

namespace RH.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validatonResult = await validator.ValidateAsync(request.LeaveRequestDto!);

            if (validatonResult.IsValid == false)
                throw new ValidationException(validatonResult); 

            var leaveRequest = await _leaveRequestRepository.Get(request.Id);

            if (request.LeaveRequestDto is not null)
            {
                _mapper.Map(request.LeaveRequestDto, leaveRequest);

                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovalDto is not null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved); 
            }

            return Unit.Value;
        }
    }
}
