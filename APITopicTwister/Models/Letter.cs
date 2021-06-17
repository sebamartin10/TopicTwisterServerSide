using System.ComponentModel.DataAnnotations;

namespace APITopicTwister.Models
{
    public class Letter
    {
        [Key]
        public string LetterID { get; set; }
    }
}