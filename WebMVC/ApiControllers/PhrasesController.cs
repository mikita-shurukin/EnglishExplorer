using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.DAL;
using WebMVC.DAL.Models;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class PhrasesController : Controller
    {
        private readonly MainDbContext _dbContext;

        public PhrasesController(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string searchString)
        {
            var phrases = from w in _dbContext.Phrases select w;

            if (!string.IsNullOrEmpty(searchString))
            {
                phrases = phrases.Where(w => w.PhraseText.Contains(searchString) || w.Translation.Contains(searchString));
            }

            return View(await phrases.AsNoTracking().ToListAsync());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Phrases phrases)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Phrases.Add(phrases);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(Index), phrases);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var phrase = await _dbContext.Phrases.FindAsync(id);
            if (phrase == null)
            {
                return NotFound();
            }

            _dbContext.Phrases.Remove(phrase);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public IActionResult RandomPhrases()
        {
            var randomPhrase = _dbContext.Phrases.OrderBy(w => Guid.NewGuid()).FirstOrDefault();

            return View(randomPhrase);
        }
    }
}
