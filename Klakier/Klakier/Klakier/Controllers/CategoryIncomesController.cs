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
    [Route("api/CategoryIncomes")]
    public class CategoryIncomesController : Controller
    {
        private readonly _1474_SmerfetkaContext _context;

        public CategoryIncomesController(_1474_SmerfetkaContext context)
        {
            _context = context;
        }


        //ADD



        // GET: api/CategoryExpenses
        [HttpGet]
        public IEnumerable<CategoryIncome> GetCategoryIncome()
        {
            return _context.CategoryIncome;
        }

        // GET: api/Categories/5
        [HttpGet("GetCategoryIncome/{id}")]
        public async Task<IActionResult> GetCategoryIncome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CategoryIncome = await _context.CategoryIncome.SingleOrDefaultAsync(m => m.Id == id);

            if (CategoryIncome == null)
            {
                return NotFound();
            }

            return Ok(CategoryIncome);
        }
        // GET: api/Categories/5   All Acounts where user id =id  param dla rozroznienia od GetCategory(string id)

        [HttpGet("GetCategoryIncomes/{id}")]
        public IActionResult GetCategoryIncomes([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CategoryIncome = _context.CategoryIncome.Where(m => m.UserId == id);

            if (CategoryIncome == null)
            {
                return NotFound();
            }

            return Ok(CategoryIncome);
        }
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryIncome([FromRoute] int id, [FromBody] CategoryIncome CategoryIncome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != CategoryIncome.Id)
            {
                return BadRequest();
            }

            _context.Entry(CategoryIncome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryIncomeExists(id))
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
        public async Task<IActionResult> PostCategoryIncome([FromBody] CategoryExpense CategoryIncome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            _context.CategoryExpense.Add(CategoryIncome);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryIncome", new { id = CategoryIncome.Id }, CategoryIncome);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryIncome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CategoryIncome = await _context.CategoryIncome.SingleOrDefaultAsync(m => m.Id == id);
            if (CategoryIncome == null)
            {
                return NotFound();
            }

            _context.CategoryIncome.Remove(CategoryIncome);
            await _context.SaveChangesAsync();

            return Ok(CategoryIncome);
        }

        private bool CategoryIncomeExists(int id)
        {
            return _context.CategoryIncome.Any(e => e.Id == id);
        }
    }
}