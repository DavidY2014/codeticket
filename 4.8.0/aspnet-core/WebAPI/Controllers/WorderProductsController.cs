using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ORM.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorderProductsController : ControllerBase
    {
        private readonly TicketCodeTestDBContext _context;

        public WorderProductsController(TicketCodeTestDBContext context)
        {
            _context = context;
        }
        #region template
        // GET: api/WorderProducts
        [HttpGet]
        [Obsolete]
        public async Task<ActionResult<IEnumerable<WorderProduct>>> GetWorderProduct()
        {
            return await _context.WorderProduct.ToListAsync();
        }

        // GET: api/WorderProducts/5
        [HttpGet("{id}")]
        [Obsolete]
        public async Task<ActionResult<WorderProduct>> GetWorderProduct(int id)
        {
            var worderProduct = await _context.WorderProduct.FindAsync(id);

            if (worderProduct == null)
            {
                return NotFound();
            }

            return worderProduct;
        }

        // PUT: api/WorderProducts/5
        [HttpPut("{id}")]
        [Obsolete]
        public async Task<IActionResult> PutWorderProduct(int id, WorderProduct worderProduct)
        {
            if (id != worderProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(worderProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorderProductExists(id))
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

        // POST: api/WorderProducts
        [HttpPost]
        [Obsolete]
        public async Task<ActionResult<WorderProduct>> PostWorderProduct(WorderProduct worderProduct)
        {
            _context.WorderProduct.Add(worderProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorderProductExists(worderProduct.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorderProduct", new { id = worderProduct.Id }, worderProduct);
        }

        // DELETE: api/WorderProducts/5
        [HttpDelete("{id}")]
        [Obsolete]
        public async Task<ActionResult<WorderProduct>> DeleteWorderProduct(int id)
        {
            var worderProduct = await _context.WorderProduct.FindAsync(id);
            if (worderProduct == null)
            {
                return NotFound();
            }

            _context.WorderProduct.Remove(worderProduct);
            await _context.SaveChangesAsync();

            return worderProduct;
        }

        private bool WorderProductExists(int id)
        {
            return _context.WorderProduct.Any(e => e.Id == id);
        }
        #endregion

        [HttpGet("GetAll")]
        public List<WorderProduct> GetAll()
        {
            return _context.WorderProduct.ToList();
        }




    }
}
