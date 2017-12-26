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
    [Route("api/Expenses")]
    public class ExpensesController : Controller
    {
        private readonly _1474_SmerfetkaContext _context;

        public ExpensesController(_1474_SmerfetkaContext context)
        {
            _context = context;
        }


        //ADD



        // GET: api/Incomes/GetExpenses
        [HttpPost("GetExpenses")]
        public IEnumerable<Expense> GetExpenses([FromBody] List<int> list)
        {
            int[] ac = list.ToArray();

            return _context.Expense.Where(m => ac.Contains(m.AccountId));
        }
        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpense([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expense = await _context.Expense.SingleOrDefaultAsync(m => m.Id == id);

            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        // PUT: api/Expenses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense([FromRoute] int id, [FromBody] Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expense.Id)
            {
                return BadRequest();
            }

            _context.Entry(expense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
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

        // POST: api/Expenses
        [HttpPost]
        public async Task<IActionResult> PostExpense([FromBody] Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
               
            }

            _context.Expense.Add(expense);

            if (expense.IsCyclical)
            {
                var time = expense.Time;
                for (int i = 0; i < expense.DaysCycle-1; i++)
                {
                    time = GetNextCycleTime(time, expense.CycleType);
                    var cyclicExpense = new Expense()
                    {
                        Time = time,
                        AccountId = expense.AccountId,
                        DaysCycle = expense.DaysCycle,
                        IsCyclical = expense.IsCyclical,
                        Amount = expense.Amount,
                        CategoryId = expense.CategoryId,
                        CycleType = expense.CycleType,
                        CurrencyCurrency = expense.CurrencyCurrency,
                        Description = expense.Description,
                        Title = expense.Title,
                        Place = expense.Place
                    };
                    
                    _context.Expense.Add(cyclicExpense);
                }
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);
        }

        private DateTime GetNextCycleTime(DateTime expenseTime, int? expenseCycleType)
        {
            if (expenseCycleType == 1)
            {
                return expenseTime.AddDays(7);
            }

            if (expenseCycleType == 2)
            {
                return expenseTime.AddMonths(1);
            }

            if (expenseCycleType == 3)
            {
                return expenseTime.AddMonths(3);
            }

            return expenseTime.AddYears(1);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expense = await _context.Expense.SingleOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.Expense.Remove(expense);
            await _context.SaveChangesAsync();

            return Ok(expense);
        }



        private bool ExpenseExists(int id)
        {
            return _context.Expense.Any(e => e.Id == id);
        }
    }
}