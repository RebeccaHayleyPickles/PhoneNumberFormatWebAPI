using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneNumberFormatAPI.Models;

namespace PhoneNumberFormatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberItemsController : ControllerBase
    {
        private readonly PhoneNumberContext _context;

        public PhoneNumberItemsController(PhoneNumberContext context)
        {
            _context = context;
        }

        // GET: api/PhoneNumberItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneNumberItem>>> GetPhoneNumberItems()
        {
            return await _context.PhoneNumberItems.ToListAsync();
        }

        // GET: api/PhoneNumberItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneNumberItem>> GetPhoneNumberItem(long id)
        {
            var phoneNumberItem = await _context.PhoneNumberItems.FindAsync(id);

            if (phoneNumberItem == null)
            {
                return NotFound();
            }

            return phoneNumberItem;
        }

        // PUT: api/PhoneNumberItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneNumberItem(long id, PhoneNumberItem phoneNumberItem)
        {
            if (id != phoneNumberItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(phoneNumberItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneNumberItemExists(id))
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

        // POST: api/PhoneNumberItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PhoneNumberItem>> PostPhoneNumberItem(PhoneNumberItem phoneNumberItem)
        {
            _context.PhoneNumberItems.Add(phoneNumberItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhoneNumberItem), new { id = phoneNumberItem.Id }, phoneNumberItem);
        }

        // DELETE: api/PhoneNumberItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PhoneNumberItem>> DeletePhoneNumberItem(long id)
        {
            var phoneNumberItem = await _context.PhoneNumberItems.FindAsync(id);
            if (phoneNumberItem == null)
            {
                return NotFound();
            }

            _context.PhoneNumberItems.Remove(phoneNumberItem);
            await _context.SaveChangesAsync();

            return phoneNumberItem;
        }

        private bool PhoneNumberItemExists(long id)
        {
            return _context.PhoneNumberItems.Any(e => e.Id == id);
        }
    }
}
