using MediatR;
using Microsoft.AspNetCore.Mvc;
using MpManagement.Application.DTOs.LeaveType;
using MpManagement.Application.Features.LeaveTypes.Requests;
using MpManagement.Application.Features.LeaveTypes.Requests.Commands;
using MpManagement.Application.Features.LeaveTypes.Requests.Queries;
using MpManagement.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MpManagement.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LeaveTypeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LeaveTypeController(IMediator mediator)
        {
			_mediator = mediator;
		}

        // GET: api/<LeaveTypeController>
        [HttpGet]
		[ProducesResponseType(typeof(List<LeaveTypeDTO>), 200)]
		public async Task<ActionResult<List<LeaveTypeDTO>>> GetAllLeaveTypes()
		{
			var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
			return Ok(leaveTypes);
		}

		// GET api/<LeaveTypeController>/5
		[HttpGet("{id}")]
		[ProducesResponseType(typeof(LeaveTypeDTO), 200)]
		public async Task<ActionResult<LeaveTypeDTO>> GetLeaveType(int id)
		{
			var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id});
			return Ok(leaveType);
		}

		// POST api/<LeaveTypeController>
		[HttpPost]
		[ProducesResponseType(typeof(BaseCommandResponse), 200)]
		[ProducesResponseType(typeof(BaseCommandResponse), 400)]
		public async Task<ActionResult> CreateLeaveType([FromBody] CreateLeaveTypeDTO leaveTypeDto)
		{
			var command = new CreateLeaveTypeCommand { CreateLeaveTypeDto = leaveTypeDto };
			var response = await _mediator.Send(command);
			if(response.Success)
				return Ok(response);
			return BadRequest(response);
			
		}

		// PUT api/<LeaveTypeController>/5
		[HttpPut("{id}")]
		[ProducesResponseType(204)]
		public async Task<ActionResult> UpdateLeaveType([FromBody] UpdateLeaveTypeDTO leaveTypeDto)
		{
			var command = new UpdateLeaveTypeCommand { UpdateLeaveTypeDto = leaveTypeDto };
			await _mediator.Send(command);
			return NoContent();
		}

		// DELETE api/<LeaveTypeController>/5
		[HttpDelete("{id}")]
		[ProducesResponseType(204)]
		public async Task<ActionResult> DeleteLeaveType(int id)
		{
			var command = new DeleteLeaveTypeCommand { Id = id };
			await _mediator.Send(command);
			return NoContent();
		}
	}
}
