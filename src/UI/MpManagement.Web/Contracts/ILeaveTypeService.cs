using MpManagement.Web.Services.Base;
using MpManagement.Web.ViewModels.LeaveTypes;

namespace MpManagement.Web.Contracts
{
	public interface ILeaveTypeService
	{
		Task<List<LeaveTypeVM>> GetLeaveTypes();
		Task<LeaveTypeVM> GetLeaveType(int id);
		Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType);
		Task<Response<int>> UpdateLeaveType(int id, LeaveTypeVM leaveType);
		Task<Response<int>> DeleteLeaveType(int id);
	}
}
