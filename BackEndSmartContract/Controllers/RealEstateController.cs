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
    public class RealEstateController : ControllerBase
    {
        private readonly SmartPropDbContext _context;

        public RealEstateController(SmartPropDbContext context)
        {
            _context = context;
        }

        // GET: api/RealEstate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RealEstate>>> GetRealEstates()
        {
            return await _context.RealEstates.ToListAsync();
        }

        // GET: api/RealEstate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RealEstate>> GetRealEstate(int? id)
        {
            var realEstate = await _context.RealEstates.FindAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            return realEstate;
        }

        // PUT: api/RealEstate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRealEstate(int? id, RealEstate realEstate)
        {
            if (id != realEstate.ID)
            {
                return BadRequest();
            }

            _context.Entry(realEstate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealEstateExists(id))
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

        // POST: api/RealEstate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RealEstate>> PostRealEstate(RealEstate realEstate)
        {
            _context.RealEstates.Add(realEstate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRealEstate", new { id = realEstate.ID }, realEstate);
        }

        // DELETE: api/RealEstate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealEstate(int? id)
        {
            var realEstate = await _context.RealEstates.FindAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            _context.RealEstates.Remove(realEstate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RealEstateExists(int? id)
        {
            return _context.RealEstates.Any(e => e.ID == id);
        }
    }
}
