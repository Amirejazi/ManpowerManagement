using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MP_Management.Application.Exceptions;
using MP_Management.Application.Features.LeaveRequests.Requests;
using MP_Management.Domain;
using MP_Management.Contracts.Persistence;

namespace MP_Management.Application.Features.LeaveRequests.Handlers.Commands
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
