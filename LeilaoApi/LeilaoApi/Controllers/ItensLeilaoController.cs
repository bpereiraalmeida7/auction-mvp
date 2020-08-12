using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeilaoApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace LeilaoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItensLeilaoController : ControllerBase
    {
        private readonly LeilaoContext _context;

        public ItensLeilaoController(LeilaoContext context)
        {
            _context = context;
        }

        // GET: api/ItensLeilao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensLeilao>>> GetItensLeilao()
        {
            return await _context.ItensLeilao.ToListAsync();
        }

        // GET: api/ItensLeilao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItensLeilao>> GetItensLeilao(int id)
        {
            var itensLeilao = await _context.ItensLeilao.FindAsync(id);

            if (itensLeilao == null)
            {
                return NotFound();
            }

            return itensLeilao;
        }

        // PUT: api/ItensLeilao/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItensLeilao(int id, ItensLeilao itensLeilao)
        {
            if (id != itensLeilao.Id)
            {
                return BadRequest();
            }

            _context.Entry(itensLeilao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItensLeilaoExists(id))
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

        // POST: api/ItensLeilao
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ItensLeilao>> PostItensLeilao(ItensLeilao itensLeilao)
        {
            _context.ItensLeilao.Add(itensLeilao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItensLeilao", new { id = itensLeilao.Id }, itensLeilao);
        }

        // DELETE: api/ItensLeilao/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItensLeilao>> DeleteItensLeilao(int id)
        {
            var itensLeilao = await _context.ItensLeilao.FindAsync(id);
            if (itensLeilao == null)
            {
                return NotFound();
            }

            _context.ItensLeilao.Remove(itensLeilao);
            await _context.SaveChangesAsync();

            return itensLeilao;
        }

        private bool ItensLeilaoExists(int id)
        {
            return _context.ItensLeilao.Any(e => e.Id == id);
        }
    }
}
