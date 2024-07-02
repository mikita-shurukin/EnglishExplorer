using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebMVC.DAL;
using WebMVC.DAL.Models;

public class GrammarController : Controller
{
    private readonly MainDbContext _context;

    public GrammarController(MainDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var topics = _context.GrammarTopics.ToList();
        return View(topics);
    }

    [HttpGet]
    public IActionResult CreateTopic()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateTopic(GrammarTopic topic)
    {
        if (ModelState.IsValid)
        {
            _context.GrammarTopics.Add(topic);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(topic);
    }

    public IActionResult ViewTopic(int id)
    {
        var topic = _context.GrammarTopics
            .Include(t => t.Contents)
            .Include(t => t.TestQuestions)
            .FirstOrDefault(t => t.Id == id);

        if (topic == null)
        {
            return NotFound();
        }

        return View(topic);
    }

    [HttpGet]
    public IActionResult AddContent(int topicId)
    {
        var model = new GrammarContent { GrammarTopicId = topicId };
        return View(model);
    }

    [HttpPost]
    public IActionResult AddContent(GrammarContent content)
    {
        if (ModelState.IsValid)
        {
            _context.GrammarContents.Add(content);
            _context.SaveChanges();
            return RedirectToAction(nameof(ViewTopic), new { id = content.GrammarTopicId });
        }
        return View(content);
    }

    [HttpGet]
    public IActionResult AddQuestion(int topicId)
    {
        var model = new TestQuestion { GrammarTopicId = topicId };
        return View(model);
    }

    [HttpPost]
    public IActionResult AddQuestion(TestQuestion question)
    {
        if (ModelState.IsValid)
        {
            _context.TestQuestions.Add(question);
            _context.SaveChanges();
            return RedirectToAction(nameof(ViewTopic), new { id = question.GrammarTopicId });
        }
        return View(question);
    }

    public IActionResult Test(int id)
    {
        var questions = _context.TestQuestions
            .Include(q => q.Answers)
            .Where(q => q.GrammarTopicId == id)
            .ToList();

        if (questions.Count == 0)
        {
            return NotFound();
        }

        return View(questions);
    }

    [HttpPost]
    public IActionResult SubmitTest(List<TestQuestion> questions)
    {
        int correctAnswers = 0;
        foreach (var question in questions)
        {
            var correctAnswer = _context.TestAnswers.FirstOrDefault(a => a.QuestionId == question.Id && a.IsCorrect);
            if (correctAnswer != null && correctAnswer.AnswerText == question.SelectedAnswer)
            {
                correctAnswers++;
            }
        }
        ViewBag.Score = correctAnswers;
        return View("TestResult");
    }
}
