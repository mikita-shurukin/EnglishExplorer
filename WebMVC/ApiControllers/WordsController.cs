using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.DAL;
using WebMVC.DAL.Models;
using System.Threading.Tasks;
using System.Linq;

namespace WebMVC.Controllers
{
    public class WordsController : Controller
    {
        private readonly MainDbContext _dbContext;

        public WordsController(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string searchString)
        {
            var words = from w in _dbContext.Words select w;

            if (!string.IsNullOrEmpty(searchString))
            {
                words = words.Where(w => w.WordText.Contains(searchString) || w.Translation.Contains(searchString));
            }

            return View(await words.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Word word)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Words.Add(word);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = word.Id }, word);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var word = await _dbContext.Words.FindAsync(id);
            if (word == null)
            {
                return NotFound();
            }

            _dbContext.Words.Remove(word);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public IActionResult RandomWords()
        {
            var randomWord = _dbContext.Words.OrderBy(w => Guid.NewGuid()).FirstOrDefault();
            return View(randomWord);
        }
    }
}
