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
    [Route("api/Places")]
    public class PlacesController : Controller
    {
        private readonly _1474_SmerfetkaContext _context;

        public PlacesController(_1474_SmerfetkaContext context)
        {
            _context = context;
        }


        //ADD



        // GET: api/Places
        [HttpGet]
        public IEnumerable<Place> GetPlace()
        {
            return _context.Place;
        }

        // GET: api/Places/5
        [HttpGet("GetPlace/{id}")]
        public async Task<IActionResult> GetPlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Place = await _context.Place.SingleOrDefaultAsync(m => m.Id == id);

            if (Place == null)
            {
                return NotFound();
            }

            return Ok(Place);
        }
        // GET: api/Places/5   All Acounts where user id =id  param dla rozroznienia od GetPlace(string id)

        [HttpGet("GetPlaces/{id}")]
        public IActionResult GetPlaces([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Place = _context.Place.Where(m => m.UserId == id);

            if (Place == null)
            {
                return NotFound();
            }

            return Ok(Place);
        }
        // PUT: api/Places/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlace([FromRoute] int id, [FromBody] Place Place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Place.Id)
            {
                return BadRequest();
            }

            _context.Entry(Place).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceExists(id))
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

        // POST: api/Places
        [HttpPost]
        public async Task<IActionResult> PostPlace([FromBody] Place Place)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            _context.Place.Add(Place);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlace", new { id = Place.Id }, Place);
        }

        // DELETE: api/Places/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlace([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Place = await _context.Place.SingleOrDefaultAsync(m => m.Id == id);
            if (Place == null)
            {
                return NotFound();
            }

            _context.Place.Remove(Place);
            await _context.SaveChangesAsync();

            return Ok(Place);
        }

        private bool PlaceExists(int id)
        {
            return _context.Place.Any(e => e.Id == id);
        }
    }
}