namespace MP_Management.Application.DTOs.LeaveRequest
{
	public class UpdateLeaveRequestDTO: CreateLeaveRequestDTO
	{
		public bool Canceled { get; set; }
	}
}
