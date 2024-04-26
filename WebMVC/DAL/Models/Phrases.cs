using System.ComponentModel.DataAnnotations;

namespace WebMVC.DAL.Models
{
    public class Phrases
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PhraseText { get; set; }

        [Required]
        public string Translation { get; set; }
    }
}
