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
    [Route("api/Incomes")]
    public class IncomesController : Controller
    {
        private readonly _1474_SmerfetkaContext _context;

        public IncomesController(_1474_SmerfetkaContext context)
        {
            _context = context;
        }

        // GET: api/Incomes/GetIncomes
        [HttpPost("GetIncomes")]
        public IEnumerable<Income> GetIncomes([FromBody] List<int> list)
        {
            int[] ac = list.ToArray();

            return _context.Income.Where(m => ac.Contains(m.AccountId));
        }

        // GET: api/Incomes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var income = await _context.Income.SingleOrDefaultAsync(m => m.Id == id);

            if (income == null)
            {
                return NotFound();
            }

            return Ok(income);
        }

        // PUT: api/Incomes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncome([FromRoute] int id, [FromBody] Income income)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != income.Id)
            {
                return BadRequest();
            }

            _context.Entry(income).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(id))
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

        // POST: api/Incomes
        [HttpPost]
        public async Task<IActionResult> PostIncome([FromBody] Income income)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Income.Add(income);
            if (income.IsCyclical)
            {
                var time = income.Time;
                for (int i = 0; i < income.DaysCycle - 1; i++)
                {
                    time = GetNextCycleTime(time, income.CycleType);
                    var cyclicIncome = new Income()
                    {
                        Time = time,
                        AccountId = income.AccountId,
                        DaysCycle = income.DaysCycle,
                        IsCyclical = income.IsCyclical,
                        Amount = income.Amount,
                        CategoryId = income.CategoryId,
                        CycleType = income.CycleType,
                        CurrencyCurrency = income.CurrencyCurrency,
                        Description = income.Description,
                        Title = income.Title
                    };

                    _context.Income.Add(cyclicIncome);
                }
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncome", new { id = income.Id }, income);
        }

        // DELETE: api/Incomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var income = await _context.Income.SingleOrDefaultAsync(m => m.Id == id);
            if (income == null)
            {
                return NotFound();
            }

            _context.Income.Remove(income);
            await _context.SaveChangesAsync();

            return Ok(income);
        }



        private bool IncomeExists(int id)
        {
            return _context.Income.Any(e => e.Id == id);
        }

        private DateTime GetNextCycleTime(DateTime incomeTime, int? incomeCycleType)
        {
            if (incomeCycleType == 1)
            {
                return incomeTime.AddDays(7);
            }

            if (incomeCycleType == 2)
            {
                return incomeTime.AddMonths(1);
            }

            if (incomeCycleType == 3)
            {
                return incomeTime.AddMonths(3);
            }

            return incomeTime.AddYears(1);
        }
    }
}