using WordSquare.Infrastructure;

namespace WordSquareTests.Fakes
{
    public class FakeDictionaryClient : IDictionaryClient
    {
        public IEnumerable<string> GetWords()
        {
            var words = new List<string>
            {
                " Cat ",
                "DOG",
                "a",
                "   ",
                "",
                "LongWord",
                "aaa",
                "Rat",
                "Pole"
            };

            return words;
        }
    }
}
