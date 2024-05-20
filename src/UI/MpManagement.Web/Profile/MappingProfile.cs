using MpManagement.Web.Services.Client.Impeliments;
using MpManagement.Web.ViewModels.LeaveTypes;

namespace MpManagement.Web.Profile
{
	public class MappingProfile : AutoMapper.Profile
	{
		public MappingProfile()
		{
			#region LeaveType Mapping
			CreateMap<LeaveTypeVM, LeaveTypeDTO>().ReverseMap();
			CreateMap<CreateLeaveTypeVM, CreateLeaveTypeDTO>().ReverseMap();
			CreateMap<LeaveTypeVM, UpdateLeaveTypeDTO>().ReverseMap();
            #endregion

            //#region LeaveRequest Mapping
            //CreateMap<LeaveRequest, LeaveRequestListDTO>().ReverseMap();
            //CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
            //CreateMap<LeaveRequest, CreateLeaveRequestDTO>().ReverseMap();
            //CreateMap<LeaveRequest, UpdateLeaveRequestDTO>().ReverseMap();
            //#endregion

            //#region LeaveAllocation Mapping
            //CreateMap<LeaveAllocation, LeaveAllocationDTO>().ReverseMap();
            //CreateMap<LeaveAllocation, CreateLeaveAllocationDTO>().ReverseMap();
            //CreateMap<LeaveAllocation, UpdateLeaveAllocationDTO>().ReverseMap();
            //#endregion

        }
	}
}
