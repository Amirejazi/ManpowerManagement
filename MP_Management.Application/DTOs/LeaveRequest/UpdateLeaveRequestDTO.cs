using MP_Management.Application.DTOs.Common;

namespace MP_Management.Application.DTOs.LeaveRequest
{
	public class UpdateLeaveRequestDTO: CreateLeaveRequestDTO
	{
        public int Id { get; set; }
        public bool Canceled { get; set; }
	}
}
