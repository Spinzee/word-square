namespace WordSquare.Infrastructure
{
    public class DictionaryClient : IDictionaryClient
    {
        public IEnumerable<string> GetWords()
        {
            var words = File.ReadAllLines("Resources/Dictionary.txt");  

            return words;
        }
    }
}
