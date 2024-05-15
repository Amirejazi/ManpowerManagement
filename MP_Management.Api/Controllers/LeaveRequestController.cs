using MediatR;
using Microsoft.AspNetCore.Mvc;
using MP_Management.Application.DTOs.LeaveRequest;
using MP_Management.Application.Features.LeaveRequests.Requests.Commands;
using MP_Management.Application.Features.LeaveRequests.Requests.Queries;
using MP_Management.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MP_Management.Api.Controllers
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
		public async Task<ActionResult<List<LeaveRequest>>> Get()
		{
			var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
			return Ok(leaveRequests);
		}

		// GET api/<LeaveRequestController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult> Get(int id)
		{
			var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailRequest { Id = id });
			return Ok(leaveRequest);
		}

		// POST api/<LeaveRequestController>
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDTO createLeaveRequestDto)
		{
			var command = new CreateLeaveRequestCommand { CreateLeaveRequestDto = createLeaveRequestDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		// PUT api/<LeaveRequestController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> Put([FromBody] UpdateLeaveRequestDTO updateLeaveRequestDto)
		{
			var command = new UpdateLeaveRequestCommand { UpdateLeaveRequestDto = updateLeaveRequestDto };
			await _mediator.Send(command);
			return NoContent();
		}

		// DELETE api/<LeaveRequestController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var command = new DeleteLeaveRequestCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}

		[HttpPut("/change-apprval/{id}")]
		public async Task<ActionResult> Put(int id , ChangeLeaveRequestApprovalDTO changeLeaveRequestApprovalDto)
		{
			var command = new ChangeLeaveRequestApprovalCommand { ChangeLeaveRequestApprovalDto = changeLeaveRequestApprovalDto };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
