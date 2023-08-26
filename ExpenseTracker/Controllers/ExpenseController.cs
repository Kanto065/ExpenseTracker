using ExpenseTracker.DB;
//using ExpenseTracker.Shared.Models;
//using ExpenseTracker.infrastracture.Interface;
//using ExpenseTracker.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using ExpenseTracker.infrastracture;
using ExpenseTracker.DB.Model;

namespace ExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        //readonly IExpenseRepository expenseRepository;
        //public ExpenseController(IExpenseRepository expenseRepository)
        //{
        //    this.expenseRepository = expenseRepository;
        //}

        private readonly ETContext _context;

        public ExpenseController(ETContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            if (startDate.HasValue && endDate.HasValue)
            {
                return RedirectToAction("FilterByDateRange", new { startDate, endDate });
            }

            var entries = _context.Expenses.Include(e => e.Categories).ToList();
            return View(entries);
        }



        // GET: ExpenseEntry/Create
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, CategoryId, Amount, ExpenseDate, Description")] Expense entry)
        {
            if (entry!=null)
            {
                if (entry.ExpenseDate > DateTime.Now)
                {
                    ModelState.AddModelError("EntryDate", "Expenditure date cannot be a future date.");
                    ViewBag.Categories = _context.Categories.ToList();
                    return View(entry);
                }
                //entry.ExpenseDate = DateTime.Now;
                await _context.Expenses.AddAsync(entry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(entry);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Expenses.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(entry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, CategoryId, Amount, ExpenseDate, Description")] Expense entry)
        {
            if (id != entry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseEntryExists(entry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(entry);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _context.Expenses
                .Include(e => e.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entry = await _context.Expenses.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseEntryExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
        public async Task<IActionResult> FilterByDateRange(DateTime startDate, DateTime endDate)
        {
            var entries = await _context.Expenses
                .Include(e => e.Categories)
                .Where(e => e.ExpenseDate >= startDate && e.ExpenseDate <= endDate)
                .ToListAsync();

            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return View("Index", entries);
        }




        //[HttpGet("expense/create")]
        //public async Task<ApiResultDTO> Create()
        //{
        //    return await this.expenseRepository.AddNewExpense(new Expense
        //    {
        //        Id = 10,
        //        Amount = 0,
        //        CategoryId = 1,
        //        ExpenseDate = DateTime.Now,
        //        Description = "hello",
        //        Name = "name",
        //        //Categories = new List<Category>()

        //    });
        //}



    }
}
