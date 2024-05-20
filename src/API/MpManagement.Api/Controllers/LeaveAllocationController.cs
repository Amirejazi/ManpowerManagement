using MediatR;
using Microsoft.AspNetCore.Mvc;
using MpManagement.Application.DTOs.LeaveAllocation;
using MpManagement.Application.Features.LeaveAllocations.Requests.Commands;
using MpManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MpManagement.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MpManagement.Api.Controllers
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
		[ProducesResponseType(typeof(List<LeaveAllocationDTO>), 200)]
		public async Task<ActionResult<List<LeaveAllocationDTO>>> GetAllLeaveAllocations()
		{
			var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
			return Ok(leaveAllocations);
		}

		// GET api/<LeaveAllocationController>/5
		[HttpGet("{id}")]
		[ProducesResponseType(typeof(LeaveAllocationDTO), 200)]
		public async Task<ActionResult<LeaveAllocationDTO>> GetLeaveAllocation(int id)
		{
			var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
			return Ok(leaveAllocation);
		}

		// POST api/<LeaveAllocationController>
		[HttpPost]
		[ProducesResponseType(typeof(BaseCommandResponse), 200)]
		[ProducesResponseType(400)]
		public async Task<ActionResult<BaseCommandResponse>> CreateLeaveAllocation([FromBody] CreateLeaveAllocationDTO createLeaveAllocationDto)
		{
			var command = new CreateLeaveAllocationCommand { CreateLeaveAllocationDto = createLeaveAllocationDto };
			var response = await _mediator.Send(command);
			if(response.Success)
				return Ok(response);
			return BadRequest(response);
		}

		// PUT api/<LeaveAllocationController>/5
		[HttpPut("{id}")]
		[ProducesResponseType(204)]
		public async Task<ActionResult> UpdateLeaveAllocation([FromBody] UpdateLeaveAllocationDTO updateLeaveAllocationDto)
		{
			var command = new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = updateLeaveAllocationDto };
			await _mediator.Send(command);
			return NoContent();
		}

		// DELETE api/<LeaveAllocationController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(204)]
		public async Task<ActionResult> DeleteLeaveAllocation(int id)
		{
			var command = new DeleteLeaveAllocationCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
