using MediatR;
using Microsoft.AspNetCore.Mvc;
using MpManagement.Application.DTOs.LeaveRequest;
using MpManagement.Application.Features.LeaveRequests.Requests.Commands;
using MpManagement.Application.Features.LeaveRequests.Requests.Queries;
using MpManagement.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MpManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveRequestController : ControllerBase
	{
		private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestController>
        [HttpGet]
		[ProducesResponseType(typeof(List<LeaveRequestDTO>), 200)]
		public async Task<ActionResult<List<LeaveRequestDTO>>> GetAllLeaveRequests()
		{
			var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
			return Ok(leaveRequests);
		}

		// GET api/<LeaveRequestController>/5
		[HttpGet("{id}")]
		[ProducesResponseType(typeof(LeaveRequestDTO), 200)]
		public async Task<ActionResult> GetLeaveRequest(int id)
		{
			var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
			return Ok(leaveRequest);
		}

		// POST api/<LeaveRequestController>
		[HttpPost]
		[ProducesResponseType(typeof(int), 200)]
		public async Task<ActionResult> CreateLeaveRequest([FromBody] CreateLeaveRequestDTO createLeaveRequestDto)
		{
			var command = new CreateLeaveRequestCommand { CreateLeaveRequestDto = createLeaveRequestDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		// PUT api/<LeaveRequestController>/5
		[HttpPut("{id}")]
		[ProducesResponseType(204)]
		public async Task<ActionResult> updateLeaveRequest([FromBody] UpdateLeaveRequestDTO updateLeaveRequestDto)
		{
			var command = new UpdateLeaveRequestCommand { UpdateLeaveRequestDto = updateLeaveRequestDto };
			await _mediator.Send(command);
			return NoContent();
		}

		// DELETE api/<LeaveRequestController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(204)]
		public async Task<ActionResult> DeleteLEaveRequest(int id)
		{
			var command = new DeleteLeaveRequestCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpPut("/change-apprval/{id}")]
		[ProducesResponseType(204)]
		public async Task<ActionResult> ChangeApproval(int id , ChangeLeaveRequestApprovalDTO changeLeaveRequestApprovalDto)
		{
			var command = new ChangeLeaveRequestApprovalCommand { ChangeLeaveRequestApprovalDto = changeLeaveRequestApprovalDto };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
