using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.ORM.Models;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WcustomersController : ControllerBase
    {
        private readonly TicketCodeTestDBContext _context;

        public WcustomersController(TicketCodeTestDBContext context)
        {
            _context = context;
        }

        #region template
        //GET: api/Wcustomers
       [HttpGet]
       [Obsolete]
        public async Task<ActionResult<IEnumerable<Wcustomer>>> GetWcustomer()
        {
            return await _context.Wcustomer.ToListAsync();
        }

        // GET: api/Wcustomers/5
        [HttpGet("{id}")]
        [Obsolete]
        public async Task<ActionResult<Wcustomer>> GetWcustomer(int id)
        {
            var wcustomer = await _context.Wcustomer.FindAsync(id);

            if (wcustomer == null)
            {
                return NotFound();
            }

            return wcustomer;
        }

        // PUT: api/Wcustomers/5
        [HttpPut("{id}")]
        [Obsolete]
        public async Task<IActionResult> PutWcustomer(int id, Wcustomer wcustomer)
        {
            if (id != wcustomer.UserId)
            {
                return BadRequest();
            }

            _context.Entry(wcustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WcustomerExists(id))
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

        // POST: api/Wcustomers
        [HttpPost]
        [Obsolete]
        public async Task<ActionResult<Wcustomer>> PostWcustomer(Wcustomer wcustomer)
        {
            _context.Wcustomer.Add(wcustomer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WcustomerExists(wcustomer.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWcustomer", new { id = wcustomer.UserId }, wcustomer);
        }

        // DELETE: api/Wcustomers/5
        [HttpDelete("{id}")]
        [Obsolete]
        public async Task<ActionResult<Wcustomer>> DeleteWcustomer(int id)
        {
            var wcustomer = await _context.Wcustomer.FindAsync(id);
            if (wcustomer == null)
            {
                return NotFound();
            }

            _context.Wcustomer.Remove(wcustomer);
            await _context.SaveChangesAsync();

            return wcustomer;
        }

        private bool WcustomerExists(int id)
        {
            return _context.Wcustomer.Any(e => e.UserId == id);
        }

        #endregion

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [HttpGet("Login")]
        public ResultMsg<bool> Login(string username,string password)
        {
            var ret = new ResultMsg<bool>() { data = false };
            var efCustomer = _context.Wcustomer.Where(item => item.UserName == username && item.Password == password).ToList();
            if (efCustomer.Count > 0)
            {
                ret.data = true;
            }
            return ret;
        }

        [HttpPost("Register")]
        public ResultMsg<bool> Register(string username,string password)
        {
            var ret = new ResultMsg<bool>() { data = false };
            var efCustomer = new Wcustomer();
            efCustomer.UserName = username;
            efCustomer.Password = password;
            _context.Wcustomer.Add(efCustomer);
            _context.SaveChanges();
            return ret; 
        }

        



    }
}
