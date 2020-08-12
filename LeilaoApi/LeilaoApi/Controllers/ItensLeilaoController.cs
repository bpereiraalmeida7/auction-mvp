using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeilaoApi.Models;
using Microsoft.AspNetCore.Authorization;
using LeilaoApi.Repository;
using System;

namespace LeilaoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItensLeilaoController : ControllerBase
    {
        private readonly IItensLeilaoRepository _itensRepository;

        public ItensLeilaoController(IItensLeilaoRepository itensRepository)
        {
            _itensRepository = itensRepository;
        }


        // GET: api/ItensLeilao
        [HttpGet]
        public async Task<ActionResult> GetItensLeilao()
        {
            try
            {
                var items = await _itensRepository.GetItensLeilao();
                if (items == null)
                {
                    return NotFound();
                }

                return Ok(items);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: api/ItensLeilao/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetItensLeilao(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var item = await _itensRepository.GetItemLeilao(id);

                if (item == null)
                {
                    return NotFound();
                }

                return Ok(item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
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

            try
            {
                await _itensRepository.UpdateItemLeilao(itensLeilao);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/ItensLeilao
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult> PostItensLeilao(ItensLeilao itensLeilao)
        {
            await _itensRepository.AddItemLeilao(itensLeilao);

            return CreatedAtAction("GetItensLeilao", new { id = itensLeilao.Id }, itensLeilao);
        }

        // DELETE: api/ItensLeilao/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItensLeilao(int? id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _itensRepository.DeleteItemLeilao(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}
