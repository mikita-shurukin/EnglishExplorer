namespace WebMVC.DAL.Models
{
    public class TestAnswer
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public TestQuestion? Question { get; set; } // Навигационное свойство

        public string? AnswerText { get; set; }
        public bool IsCorrect { get; set; }
    }

}
