using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MpManagement.Application.Exceptions;
using MpManagement.Domain;
using MpManagement.Application.Contracts.Persistence;
using MpManagement.Application.Features.LeaveRequests.Requests.Commands;

namespace MpManagement.Application.Features.LeaveRequests.Handlers.Commands
{
    public class DeleteLeaveRequestCommandHandler: IRequestHandler<DeleteLeaveRequestCommand>
	{
		private readonly ILeaveRequestRepository _leaveRequestRepository;
		private readonly IMapper _mapper;

		public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
		{
			_leaveRequestRepository = leaveRequestRepository;
			_mapper = mapper;
		}

		public async Task Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
		{
			var leaveRequest = await _leaveRequestRepository.GetEntityBYId(request.Id);
			if (leaveRequest == null) 
				throw new NotFoundException(nameof(LeaveRequest), request.Id);

			await _leaveRequestRepository.DeleteEntity(leaveRequest);
		}
	}
}
