using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Controllers;
using WebMVC.DAL;
using WebMVC.DAL.Models;
using Xunit;

namespace WebMVC.Tests
{
    public class WordsControllerTests
    {
        private WordsController CreateController(DbContextOptions<MainDbContext> options)
        {
            var dbContext = new MainDbContext(options);
            return new WordsController(dbContext);
        }

        private DbContextOptions<MainDbContext> CreateDbContextOptions()
        {
            return new DbContextOptionsBuilder<MainDbContext>()
                .UseInMemoryDatabase(databaseName: "WordsDatabase")
                .Options;
        }

        [Fact]
        public async Task Get_ReturnsViewResult_WithListOfWords()
        {
            var options = CreateDbContextOptions();

            using (var context = new MainDbContext(options))
            {
                context.Words.AddRange(
                    new Word { WordText = "hello", Translation = "привет" },
                    new Word { WordText = "world", Translation = "мир" }
                );
                context.SaveChanges();
            }

            using (var context = new MainDbContext(options))
            {
                var controller = CreateController(options);
                var result = await controller.Get("hello");

                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<Word>>(viewResult.ViewData.Model);
                Assert.Single(model);
            }
        }

        [Fact]
        public void Create_ReturnsViewResult()
        {
            var options = CreateDbContextOptions();
            var controller = CreateController(options);

            var result = controller.Create();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Create_ValidModel_ReturnsCreatedAtActionResult()
        {
            var options = CreateDbContextOptions();
            var newWord = new Word { WordText = "test", Translation = "тест" };

            using (var context = new MainDbContext(options))
            {
                var controller = CreateController(options);
                var result = await controller.Create(newWord);

                var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
                Assert.Equal(nameof(controller.Get), createdAtActionResult.ActionName);

                var word = Assert.IsType<Word>(createdAtActionResult.Value);
                Assert.Equal("test", word.WordText);
            }
        }

        [Fact]
        public async Task Create_InvalidModel_ReturnsBadRequest()
        {
            var options = CreateDbContextOptions();
            var newWord = new Word { WordText = "", Translation = "" };

            using (var context = new MainDbContext(options))
            {
                var controller = CreateController(options);
                controller.ModelState.AddModelError("WordText", "Required");

                var result = await controller.Create(newWord);

                Assert.IsType<BadRequestObjectResult>(result);
            }
        }

        [Fact]
        public async Task Delete_ValidId_ReturnsNoContent()
        {
            var options = CreateDbContextOptions();

            using (var context = new MainDbContext(options))
            {
                context.Words.Add(new Word { Id = 1, WordText = "test", Translation = "тест" });
                context.SaveChanges();
            }

            using (var context = new MainDbContext(options))
            {
                var controller = CreateController(options);
                var result = await controller.Delete(1);

                Assert.IsType<NoContentResult>(result);
            }
        }

        [Fact]
        public async Task Delete_InvalidId_ReturnsNotFound()
        {
            var options = CreateDbContextOptions();
            var controller = CreateController(options);

            var result = await controller.Delete(999);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void RandomWords_ReturnsViewResult_WithRandomWord()
        {
            var options = CreateDbContextOptions();

            using (var context = new MainDbContext(options))
            {
                context.Words.AddRange(
                    new Word { WordText = "hello", Translation = "привет" },
                    new Word { WordText = "world", Translation = "мир" }
                );
                context.SaveChanges();
            }

            using (var context = new MainDbContext(options))
            {
                var controller = CreateController(options);
                var result = controller.RandomWords();

                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsType<Word>(viewResult.ViewData.Model);
                Assert.NotNull(model);
            }
        }
    }
}
