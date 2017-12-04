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
    [Route("api/CategoryExpenses")]
    public class CategoryExpensesController : Controller
    {
        private readonly _1474_SmerfetkaContext _context;

        public CategoryExpensesController(_1474_SmerfetkaContext context)
        {
            _context = context;
        }


        //ADD



        // GET: api/CategoryExpenses
        [HttpGet]
        public IEnumerable<CategoryExpense> GetCategoryExpense()
        {
            return _context.CategoryExpense;
        }

        // GET: api/Categories/5
        [HttpGet("GetCategoryExpense/{id}")]
        public async Task<IActionResult> GetCategoryExpense([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CategoryExpense = await _context.CategoryExpense.SingleOrDefaultAsync(m => m.Id == id);

            if (CategoryExpense == null)
            {
                return NotFound();
            }

            return Ok(CategoryExpense);
        }
        // GET: api/Categories/5   All Acounts where user id =id  param dla rozroznienia od GetCategory(string id)

        [HttpGet("GetCategoryExpenses/{id}")]
        public IActionResult GetCategoryExpenses([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CategoryExpense = _context.CategoryExpense.Where(m => m.UserId == id);

            if (CategoryExpense == null)
            {
                return NotFound();
            }

            return Ok(CategoryExpense);
        }
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory([FromRoute] int id, [FromBody] CategoryExpense CategoryExpense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != CategoryExpense.Id)
            {
                return BadRequest();
            }

            _context.Entry(CategoryExpense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExpenseExists(id))
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

        // POST: api/Categories
        [HttpPost]
        public async Task<IActionResult> PostCategoryExpense([FromBody] CategoryExpense CategoryExpense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            _context.CategoryExpense.Add(CategoryExpense);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryExpense", new { id = CategoryExpense.Id }, CategoryExpense);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryExpense([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CategoryExpense = await _context.CategoryExpense.SingleOrDefaultAsync(m => m.Id == id);
            if (CategoryExpense == null)
            {
                return NotFound();
            }

            _context.CategoryExpense.Remove(CategoryExpense);
            await _context.SaveChangesAsync();

            return Ok(CategoryExpense);
        }

        private bool CategoryExpenseExists(int id)
        {
            return _context.CategoryExpense.Any(e => e.Id == id);
        }
    }
}