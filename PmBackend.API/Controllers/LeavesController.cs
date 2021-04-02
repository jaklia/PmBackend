using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmBackend.API.DTOs.Leaves;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;

namespace PmBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly ILeaveService _leaveService;
        public LeavesController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        // GET: api/Leaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveDto>>> GetLeavesAsync()
        {
            var leaves = await _leaveService.GetLeavesAsync();
            var leavesDto = leaves.Select(a => new LeaveDto(a));
            return Ok(leavesDto);
        }

        // GET: api/Leaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveDto>> GetLeaveAsync(int id)
        {
            try
            {
                var leave = await _leaveService.GetLeaveAsync(id);
                var leaveDto = new LeaveDto(leave);
                return Ok(leave);
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Leaves
        [HttpPost]
        public async Task<ActionResult<LeaveDto>> CreateLeaveAsync([FromBody] CreateLeaveDto value)
        {
            var newLeave = value.ToModel();
            var leave = await _leaveService.InsertLeaveAsync(newLeave);
            var leaveDto = new LeaveDto(leave);
            return Ok(leaveDto);
        }

        // PUT: api/Leaves/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeaveAsync(int id, [FromBody] UpdateLeaveDto updatedLeave)
        {
            try
            {
                var updatedModel = updatedLeave.ToModel(id);
                await _leaveService.UpdateLeaveAsync(id, updatedModel);
                return Ok();
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLeaveAsync(int id)
        {
            try
            {
                await _leaveService.DeleteLeaveAsync(id);
                return Ok();
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
