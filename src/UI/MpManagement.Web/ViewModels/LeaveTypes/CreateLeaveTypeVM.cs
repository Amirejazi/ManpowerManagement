using System.ComponentModel.DataAnnotations;

namespace MpManagement.Web.ViewModels.LeaveTypes
{
	public class CreateLeaveTypeVM
	{
		[Required]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Default Number Of Days")]
		public int DefaultDay { get; set; }
	}
}
