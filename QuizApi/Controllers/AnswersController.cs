using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApi.Models;

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : Controller
    {
        private readonly QuizDbContext _context;

        public AnswersController(QuizDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Answers.
        /// </summary>

        // GET: api/Answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAnwers()
        {
            return await _context.Answers
                .ToListAsync();
        }

        //    // GET: Answers
        //    public async Task<IActionResult> Index()
        //    {
        //        return View(await _context.Answers.ToListAsync());
        //    }

        //    // GET: Answers/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var answer = await _context.Answers
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (answer == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(answer);
        //    }

        //    // GET: Answers/Create
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Answers/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("Id,QuestionId,Content")] Answer answer)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(answer);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(answer);
        //    }

        //    // GET: Answers/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var answer = await _context.Answers.FindAsync(id);
        //        if (answer == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(answer);
        //    }

        //    // POST: Answers/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,QuestionId,Content")] Answer answer)
        //    {
        //        if (id != answer.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(answer);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!AnswerExists(answer.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(answer);
        //    }

        //    // GET: Answers/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var answer = await _context.Answers
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (answer == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(answer);
        //    }

        //    // POST: Answers/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var answer = await _context.Answers.FindAsync(id);
        //        _context.Answers.Remove(answer);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool AnswerExists(int id)
        //    {
        //        return _context.Answers.Any(e => e.Id == id);
        //    }
    }
}
