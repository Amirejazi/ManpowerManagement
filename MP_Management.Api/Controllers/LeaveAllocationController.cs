using MediatR;
using Microsoft.AspNetCore.Mvc;
using MP_Management.Application.DTOs.LeaveAllocation;
using MP_Management.Application.Features.LeaveAllocations.Requests.Commands;
using MP_Management.Application.Features.LeaveAllocations.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MP_Management.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveAllocationController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LeaveAllocationController(IMediator mediator)
        {
			_mediator = mediator;
		}

		// GET: api/<LeaveAllocationController>
		[HttpGet]
		public async Task<ActionResult<List<LeaveAllocationDTO>>> Get()
		{
			var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
			return Ok(leaveAllocations);
		}

		// GET api/<LeaveAllocationController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<LeaveAllocationDTO>> Get(int id)
		{
			var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
			return Ok(leaveAllocation);
		}

		// POST api/<LeaveAllocationController>
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDTO createLeaveAllocationDto)
		{
			var command = new CreateLeaveAllocationCommand { CreateLeaveAllocationDto = createLeaveAllocationDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		// PUT api/<LeaveAllocationController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDTO updateLeaveAllocationDto)
		{
			var command = new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = updateLeaveAllocationDto };
			await _mediator.Send(command);
			return NoContent();
		}

		// DELETE api/<LeaveAllocationController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var command = new DeleteLeaveAllocationCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
