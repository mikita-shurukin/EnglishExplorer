using System.Collections.Generic;

namespace WebMVC.DAL.Models
{
    public class GrammarTopic
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<GrammarContent>? Contents { get; set; }
        public ICollection<TestQuestion>? TestQuestions { get; set; }
    }
}
