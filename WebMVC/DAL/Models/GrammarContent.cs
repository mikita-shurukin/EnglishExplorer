namespace WebMVC.DAL.Models;
public class GrammarContent
{
    public int Id { get; set; }
    public int? GrammarTopicId { get; set; }
    public string? ContentText { get; set; }
    public GrammarTopic? GrammarTopic { get; set; }
}
