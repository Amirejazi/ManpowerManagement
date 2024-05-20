using MediatR;
using MpManagement.Application.DTOs.LeaveRequest.Validators;
using MpManagement.Application.Exceptions;
using MpManagement.Application.Features.LeaveRequests.Requests.Commands;
using MpManagement.Application.Contracts.Persistence;
using MpManagement.Domain;

namespace MpManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class ChangeLeaveRequestApprovalHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public ChangeLeaveRequestApprovalHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<int> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
			var validator = new ChangeLeaveRequestApprovalDtoValidator();
			var validationResult = await validator.ValidateAsync(request.ChangeLeaveRequestApprovalDto);
			if (!validationResult.IsValid)
				throw new ValidationException(validationResult);

			var leaveRequest = await _leaveRequestRepository.GetEntityBYId(request.ChangeLeaveRequestApprovalDto.Id);
            if (leaveRequest == null)
				throw new NotFoundException(nameof(LeaveRequest), request.ChangeLeaveRequestApprovalDto.Id);
            await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
            return leaveRequest.Id;
        }
    }
}
