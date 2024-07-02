using System.Collections.Generic;
namespace WebMVC.DAL.Models;

public class TestQuestion
{
    public int Id { get; set; }
    public int? GrammarTopicId { get; set; }
    public GrammarTopic? GrammarTopic { get; set; } // Навигационное свойство

    public string? QuestionText { get; set; }
    public List<TestAnswer>? Answers { get; set; }

    public string? SelectedAnswer { get; set; }
}
