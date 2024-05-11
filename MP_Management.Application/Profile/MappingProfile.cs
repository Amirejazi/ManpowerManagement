using MP_Management.Application.DTOs.LeaveAllocation;
using MP_Management.Application.DTOs.LeaveRequest;
using MP_Management.Application.DTOs.LeaveType;
using MP_Management.Domain;

namespace MP_Management.Profile
{
    public class MappingProfile: AutoMapper.Profile
	{
		public MappingProfile()
		{
			CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
			CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
			CreateMap<LeaveRequest, LeaveRequestListDTO>().ReverseMap();
			CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
		}
	}
}
