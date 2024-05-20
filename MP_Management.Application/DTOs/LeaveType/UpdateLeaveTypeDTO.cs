using MP_Management.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Management.Application.DTOs.LeaveType
{
	public class UpdateLeaveTypeDTO : BaseDTO, ILeaveTypeDTO
	{
		public string Name { get; set ; }
		public int DefaultDay { get; set; }
	}
}
