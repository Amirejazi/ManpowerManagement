using MP_Management.Application.DTOs.Common;

namespace MP_Management.Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDTO : BaseDTO, ILeaveTypeDTO
	{
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
