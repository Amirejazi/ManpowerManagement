using Microsoft.AspNetCore.Mvc;
using MpManagement.Web.Contracts;
using MpManagement.Web.ViewModels.LeaveTypes;

namespace MpManagement.Web.Controllers
{
	public class LeaveTypeController : Controller
	{
		private readonly ILeaveTypeService _leaveTypeService;

		public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
			_leaveTypeService = leaveTypeService;
		}

		[HttpGet]
        public async Task<IActionResult> Index()
		{
			var leaveTypes = await _leaveTypeService.GetLeaveTypes();
			return View(leaveTypes);
		}

        [HttpGet("create-leave-type")]
        public async Task<IActionResult> CreateLeaveType()
        {
            return View();
        }

        [HttpPost("create-leave-type")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLeaveType(CreateLeaveTypeVM createLeaveType)
        {
			if (ModelState.IsValid)
			{
                var response = await _leaveTypeService.CreateLeaveType(createLeaveType);
                if (response.Success)
                    return RedirectToAction("Index");
                ModelState.AddModelError("Name", response.ValidationErrors);
            }
			return View(createLeaveType);
        }

        [HttpGet("edit-leave-type/{id}")]
        public async Task<IActionResult> EditLeaveType(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveType(id);
            return View(leaveType);
        }

        [HttpPost("edit-leave-type/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLeaveType(int id, LeaveTypeVM leaveType)
        {
            if (ModelState.IsValid)
            {
                var response = await _leaveTypeService.UpdateLeaveType(id, leaveType);
                if(response.Success)
                    return RedirectToAction("Index");
                ModelState.AddModelError("Name", response.ValidationErrors);
            }
            return View(leaveType);
        }

        [HttpGet("leave-type/{id}")]
        public async Task<IActionResult> LeaveTypeDetails(int id)
        {
            var leaveType = await _leaveTypeService.GetLeaveType(id);
            return View(leaveType);
        }

        [HttpGet("delete-leave-type/{id}")]
        public async Task<IActionResult> DeleteLeaveType(int id)
        {
            var response = await _leaveTypeService.DeleteLeaveType(id);
            if (response.Success)
                return RedirectToAction("Index");
            else
                return BadRequest();
        }
    }
}
