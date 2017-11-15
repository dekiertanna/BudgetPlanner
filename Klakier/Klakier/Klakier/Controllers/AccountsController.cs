using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Klakier;

namespace Klakier.Controllers
{
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private readonly _1474_SmerfetkaContext _context;

        public AccountsController(_1474_SmerfetkaContext context)
        {
            _context = context;
        }


        //ADD



        // GET: api/Accounts
        [HttpGet]
        public IEnumerable<Account> GetAccount()
        {
            return _context.Account;
        }

        // GET: api/Accounts/5
        [HttpGet("GetAccount/{id}")]
        public async Task<IActionResult> GetAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Account = await _context.Account.SingleOrDefaultAsync(m => m.Id == id);

            if (Account == null)
            {
                return NotFound();
            }

            return Ok(Account);
        }
        // GET: api/Accounts/5   All Acounts where user id =id  param dla rozroznienia od GetAccount(string id)

        [HttpGet("GetAccounts/{id}")]
        public IActionResult GetAccounts([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = _context.Account.Where(m => m.UserId == id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }
        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount([FromRoute] int id, [FromBody] Account Account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Account.Id)
            {
                return BadRequest();
            }

            _context.Entry(Account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        // POST: api/Accounts
        [HttpPost]
        public async Task<IActionResult> PostAccount([FromBody] Account Account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            _context.Account.Add(Account);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = Account.Id }, Account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Account = await _context.Account.SingleOrDefaultAsync(m => m.Id == id);
            if (Account == null)
            {
                return NotFound();
            }

            _context.Account.Remove(Account);
            await _context.SaveChangesAsync();

            return Ok(Account);
        }

        private bool AccountExists(int id)
        {
            return _context.Account.Any(e => e.Id == id);
        }
    }
}