
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Quries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRLeaveManagement.Api.Controllers
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
        [HttpGet("GetAllLeaveType")]
        public async Task<ActionResult<List<LeaveTypeDto>>> GetAllLeaveType()
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveType);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("GetLeaveType/{id}")]
        public async Task<ActionResult<LeaveTypeDto>> GetLeaveType(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest { Id = id});
            return Ok(leaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost("CreateLeaveType")]
        public async Task<ActionResult> CreateLeaveType([FromBody] CreateLeaveTypeDto leaveType)
        {
            var command = new CreateLeaveTypeCommand { LeaveTypeDto = leaveType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut("UpdateLeaveType/{id}")]
        public async Task<ActionResult> UpdateLeaveType(int id, [FromBody] LeaveTypeDto leaveType)
        {
            var command = new UpdateLeaveTypeCommand { LeaveTypeDto = leaveType };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("DeleteLeaveType/{id}")]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            var command = new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
