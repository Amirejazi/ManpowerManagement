using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MpManagement.Application.DTOs.Common;
using MpManagement.Domain;

namespace MpManagement.Application.DTOs.LeaveRequest
{
	public class LeaveRequestListDTO: BaseDTO
	{
		public int LeaveTypeId { get; set; }
		public DateTime DateRequest { get; set; }
		public bool Aproved { get; set; }
	}
}
