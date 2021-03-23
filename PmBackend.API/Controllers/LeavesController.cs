using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Leave> Get()
        {
            return _leaveService.GetLeaves();
        }

        // GET: api/Leaves/5
        [HttpGet("{id}", Name = "GetLeave")]
        public Leave Get(int leaveId)
        {
            return _leaveService.GetLeave(leaveId);
        }

        // POST: api/Leaves
        [HttpPost]
        public Leave Post([FromBody] Leave newLeave)
        {
            return _leaveService.InsertLeave(newLeave);
        }

        // PUT: api/Leaves/5
        [HttpPut("{id}")]
        public void Put(int leaveId, [FromBody] Leave updatedLeave)
        {
            _leaveService.UpdateLeave(leaveId, updatedLeave);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int leaveId)
        {
            _leaveService.DeleteLeave(leaveId);
        }
    }
}
