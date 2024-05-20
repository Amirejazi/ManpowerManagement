using MpManagement.Application.DTOs.LeaveAllocation;
using MpManagement.Application.DTOs.LeaveRequest;
using MpManagement.Application.DTOs.LeaveType;
using MpManagement.Domain;

namespace MpManagement.Profile
{
    public class MappingProfile: AutoMapper.Profile
	{
		public MappingProfile()
		{
			#region LeaveType Mapping
				CreateMap<LeaveType, LeaveTypeDTO>().ReverseMap();
				CreateMap<LeaveType, CreateLeaveTypeDTO>().ReverseMap();
				CreateMap<LeaveType, UpdateLeaveTypeDTO>().ReverseMap();
			#endregion

			#region LeaveRequest Mapping
				CreateMap<LeaveRequest, LeaveRequestListDTO>().ReverseMap();
				CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
				CreateMap<LeaveRequest, CreateLeaveRequestDTO>().ReverseMap();
				CreateMap<LeaveRequest, UpdateLeaveRequestDTO>().ReverseMap();
			#endregion

			#region LeaveAllocation Mapping
				CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
				CreateMap<LeaveAllocation, CreateLeaveAllocationDTO>().ReverseMap();
				CreateMap<LeaveAllocation, UpdateLeaveAllocationDTO>().ReverseMap();
			#endregion

		}
	}
}
