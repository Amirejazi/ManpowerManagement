using MP_Management.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Application.DTOs.LeaveRequest
{
	public class ChangeLeaveRequestApprovalDTO: BaseDTO
	{
		public bool Approved { get; set; }
	}
}
