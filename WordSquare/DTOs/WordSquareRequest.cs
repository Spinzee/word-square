using System.ComponentModel.DataAnnotations;
using WordSquare.Validators;

namespace WordSquare
{
    [ValidWordSquare]
    public class WordSquareRequest
    {
        [Required]
        public int Size { get; set; }

        [Required]
        public string Letters { get; set; }
    }
}
