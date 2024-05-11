using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MP_Management.Application.DTOs.Common;
using MP_Management.Domain;

namespace MP_Management.Application.DTOs.LeaveRequest
{
	public class LeaveRequestListDTO: BaseDTO
	{
		public Domain.LeaveType LeaveType { get; set; }
		public DateTime DateRequest { get; set; }
		public bool Aproved { get; set; }
	}
}
