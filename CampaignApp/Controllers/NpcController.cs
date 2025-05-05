using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CampaignApp.Data;
using CampaignApp.Models;

namespace CampaignApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NpcController : ControllerBase
    {
        private readonly CampaignAppDbContext _context;

        public NpcController(CampaignAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Npc>>> GetNpcs()
        {
            return await _context.Npcs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Npc>> GetNpc(int id)
        {
            var npc = await _context.Npcs.FindAsync(id);
            if (npc == null)
            {
                return NotFound();
            }

            return npc;
        }

        [HttpPost]
        public async Task<ActionResult<Npc>> PostNpc(Npc npc)
        {
            _context.Npcs.Add(npc);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNpc), new { id = npc.Id }, npc);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNpc(int id, Npc npc)
        {
            if (id != npc.Id)
            {
                return BadRequest();
            }

            _context.Entry(npc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NpcExists(id))
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

        // DELETE: api/Npc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNpc(int id)
        {
            var npc = await _context.Npcs.FindAsync(id);
            if (npc == null)
            {
                return NotFound();
            }

            _context.Npcs.Remove(npc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NpcExists(int id)
        {
            return _context.Npcs.Any(e => e.Id == id);
        }
    }
}
