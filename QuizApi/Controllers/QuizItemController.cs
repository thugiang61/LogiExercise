using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApi.Models;

namespace QuizApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiConventionType(typeof(DefaultApiConventions))]
    public class QuizItemController : ControllerBase
    {
        private readonly QuizDbContext _context;

        public QuizItemController(QuizDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all QuizItems.
        /// </summary>
        /// <response code="200">If all items are get successfully</response>
        /// <response code="404">If the data doesn't exist in the database</response>
        /// <response code="500">If there's some error in the code</response>

        // GET: api/QuizItems
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<QuizItem>>> GetQuizItems()
        {
            var quizItems = await _context.QuizItems.ToListAsync();

            foreach (var quizItem in quizItems)
            {
                var answers = await _context.Answers.Where(x => x.QuestionId == quizItem.Id).ToListAsync();

                quizItem.Answers = answers;
            }

            return quizItems;
        }

        /// <summary>
        /// Get a QuizItem by id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">If the item is get successfully</response>
        /// <response code="400">If the item is null</response>
        /// <response code="404">If the data doesn't exist in the database</response>
        /// <response code="500">If there's some error in the code</response>

        // GET: api/QuizItems/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QuizItem>> GetQuizItem(int id)
        {
            var quizItem = await _context.QuizItems.FindAsync(id);

            if (quizItem == null)
            {
                return NotFound();
            }

            var answers = await _context.Answers.Where(x => x.QuestionId == id).ToListAsync();

            quizItem.Answers = answers;

            return quizItem;
        }

        /// <summary>
        /// Update a QuizItem.
        /// </summary>
        /// <param name="quizItem"></param>
        /// <param name="id"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /QuizItem
        ///     {
        ///         "id": 2,
        ///         "question": "Khi gặp Thúy Kiều , Kim Trọng trao cho vật gì làm tin?",
        ///         "answers": [
        ///             {
        ///                  "id": 0,
        ///                  "questionId": 2,
        ///                  "content": "Dải yếm"
        ///            },
        ///            {
        ///                  "id": 3,
        ///                  "questionId": 2,
        ///                  "content": "Dải lụa"
        ///             },
        ///             {
        ///                  "id": 2,
        ///                  "questionId": 2,
        ///                  "content": "Chiếc khăn hồng"
        ///             }
        ///          ],
        ///         "rightAnswer": 0
        ///      }
        ///
        /// </remarks>
        /// <response code="200">If the item updated successfully</response>
        /// <response code="204">If the server has successfully fulfilled the request</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If there's some error in the code</response>
        /// 
        // PUT: api/QuizItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateQuizItem(int id, QuizItem quizItem)
        {
            if (id != quizItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(quizItem).State = EntityState.Modified;//update 

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!QuizItemExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Create a QuizItem.
        /// </summary>
        /// <param name="quizItem"></param>
        /// <returns>A newly created QuizItem</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /QuizItem
        ///     {
        ///         "id": 2,
        ///         "question": "Khi gặp Thúy Kiều , Kim Trọng trao cho vật gì làm tin?",
        ///         "answers": [
        ///             {
        ///                  "id": 0,
        ///                  "questionId": 2,
        ///                  "content": "Dải yếm"
        ///            },
        ///            {
        ///                  "id": 1,
        ///                  "questionId": 2,
        ///                  "content": "Miếng lụa"
        ///             },
        ///             {
        ///                  "id": 2,
        ///                  "questionId": 2,
        ///                  "content": "Chiếc khăn hồng"
        ///             }
        ///          ],
        ///         "rightAnswer": 2
        ///      }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        /// <response code="200">If the item created successfully</response>
        /// <response code="500">If there's some error in the code</response>
        /// 
        // POST: api/QuizItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<QuizItem>> CreateQuizItem(QuizItem quizItem)
        {
            _context.QuizItems.Add(quizItem);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(UpdateQuizItem),

                new { id = quizItem.Id },

                quizItem
            );
        }

        /// <summary>
        /// Delete a QuizItem by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/QuizItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizItem(int id)
        {
            var todoItem = await _context.QuizItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.QuizItems.Remove(todoItem);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizItemExists(long id)
        {
            return _context.QuizItems.Any(e => e.Id == id);
        }
    }
}