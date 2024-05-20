using MpManagement.Application.DTOs.Common;

namespace MpManagement.Application.DTOs.LeaveRequest
{
	public class UpdateLeaveRequestDTO: CreateLeaveRequestDTO
	{
        public int Id { get; set; }
        public bool Canceled { get; set; }
	}
}
