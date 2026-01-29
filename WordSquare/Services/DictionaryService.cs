using WordSquare.DomainModels;
using WordSquare.Infrastructure;

namespace WordSquare.Services
{
    public class DictionaryService 
    {
        private readonly List<WordByLength> _wordsByLength = new();

        public DictionaryService(IDictionaryClient dictionaryClient)
        {
            var words = dictionaryClient.GetWords()
                .Select(words => words.Trim().ToLower());           

            foreach (var word in words)
            {
                int len = word.Length;
                _wordsByLength.Add(new WordByLength { Word = word, Length = len });
            }
        }

        public IEnumerable<string> GetWordsOfLength(int length)
        {
            var candidates = _wordsByLength.Where(w => w.Length == length).Select(w => w.Word);
                
            return candidates;
        }

        //TODO: Add prefix filtering for performance        
        public IEnumerable<string> GetWordsOfLengthAndPrefix(int length, string prefix)
        {
            var candidates = _wordsByLength
                .Where(w => 
                w.Length == length &&
                w.Word.StartsWith(prefix))
                .Select(w => w.Word);

            return candidates;
        }
    }
}
