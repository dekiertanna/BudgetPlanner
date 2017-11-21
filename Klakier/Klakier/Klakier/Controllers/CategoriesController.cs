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
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly _1474_SmerfetkaContext _context;

        public CategoriesController(_1474_SmerfetkaContext context)
        {
            _context = context;
        }


        //ADD



        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> GetCategory()
        {
            return _context.Category;
        }

        // GET: api/Categories/5
        [HttpGet("GetCategory/{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Category = await _context.Category.SingleOrDefaultAsync(m => m.Id == id);

            if (Category == null)
            {
                return NotFound();
            }

            return Ok(Category);
        }
        // GET: api/Categories/5   All Acounts where user id =id  param dla rozroznienia od GetCategory(string id)

        [HttpGet("GetCategories/{id}")]
        public IActionResult GetCategories([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Category = _context.Category.Where(m => m.UserId == id);

            if (Category == null)
            {
                return NotFound();
            }

            return Ok(Category);
        }
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory([FromRoute] int id, [FromBody] Category Category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Category.Id)
            {
                return BadRequest();
            }

            _context.Entry(Category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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
        public async Task<IActionResult> PostCategory([FromBody] Category Category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            _context.Category.Add(Category);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = Category.Id }, Category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Category = await _context.Category.SingleOrDefaultAsync(m => m.Id == id);
            if (Category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(Category);
            await _context.SaveChangesAsync();

            return Ok(Category);
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.Id == id);
        }
    }
}