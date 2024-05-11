﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace MP_Management.Application.Features.LeaveTypes.Requests
{
	public class DeleteLeaveTypeCommand: IRequest<Unit>
	{
		public int Id { get; set; }
	}
}
