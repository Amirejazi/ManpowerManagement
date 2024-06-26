﻿using MediatR;
using MpManagement.Application.DTOs.LeaveRequest;

namespace MpManagement.Application.Features.LeaveRequests.Requests.Queries
{
	public class GetLeaveRequestDetailRequest: IRequest<LeaveRequestDTO>
	{
		public int Id { get; set; }
	}
}
