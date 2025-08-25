using AutoMapper;
using FluentValidation;
using HR.LeaveManagement.Domain;
using MediatR;
using RH.LeaveManagement.Application.DTOs.LeaveType;
using RH.LeaveManagement.Application.DTOs.LeaveType.Validators;
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
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDto!);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult);

            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);

            leaveType = await _leaveTypeRepository.Add(leaveType);

            return leaveType.Id; 
        }
    }
}
