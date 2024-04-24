using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.DAL.Models
{
    public class Word
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string WordText { get; set; }

        [Required]
        public string Translation { get; set; }
    }
}
