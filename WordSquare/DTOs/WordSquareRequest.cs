using System.ComponentModel.DataAnnotations;

namespace WordSquare
{
    public class WordSquareRequest
    {
        [Required]
        public int Size { get; set; }

        [Required]
        public string Letters { get; set; }

        public bool IsValid => Letters.Length == Size * Size;
    }
}
