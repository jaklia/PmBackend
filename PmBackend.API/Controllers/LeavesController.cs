using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL.Entities;

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
        public async Task<ActionResult<IEnumerable<Leave>>> GetLeavesAsync()
        {
            var leaves = await _leaveService.GetLeavesAsync();
            return Ok(leaves);
        }

        // GET: api/Leaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Leave>> GetLeaveAsync(int id)
        {
            try
            {
                var leave = await _leaveService.GetLeaveAsync(id);
                return Ok(leave);
            } catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Leaves
        [HttpPost]
        public async Task<ActionResult<Leave>> CreateLeaveAsync([FromBody] Leave newLeave)
        {
            var leave = await _leaveService.InsertLeaveAsync(newLeave);
            return Ok(leave);
        }

        // PUT: api/Leaves/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLeaveAsync(int id, [FromBody] Leave updatedLeave)
        {
            try
            {
                await _leaveService.UpdateLeaveAsync(id, updatedLeave);
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
