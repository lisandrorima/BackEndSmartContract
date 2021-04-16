using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndSmartContract.Models;

namespace BackEndSmartContract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealStateController : ControllerBase
    {
        private readonly SmartPropDbContext _context;

        public RealStateController(SmartPropDbContext context)
        {
            _context = context;
        }

        // GET: api/RealState
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RealState>>> GetRealStates()
        {
            return await _context.RealStates.ToListAsync();
        }

        // GET: api/RealState/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RealState>> GetRealState(int id)
        {
            var realState = await _context.RealStates.FindAsync(id);

            if (realState == null)
            {
                return NotFound();
            }

            return realState;
        }

        // PUT: api/RealState/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRealState(int id, RealState realState)
        {
            if (id != realState.ID)
            {
                return BadRequest();
            }

            _context.Entry(realState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealStateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RealState
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RealState>> PostRealState(RealState realState)
        {
            _context.RealStates.Add(realState);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RealStateExists(realState.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRealState", new { id = realState.ID }, realState);
        }

        // DELETE: api/RealState/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealState(int id)
        {
            var realState = await _context.RealStates.FindAsync(id);
            if (realState == null)
            {
                return NotFound();
            }

            _context.RealStates.Remove(realState);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RealStateExists(int id)
        {
            return _context.RealStates.Any(e => e.ID == id);
        }
    }
}
