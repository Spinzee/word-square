namespace WordSquare.Infrastructure
{
    public interface IDictionaryClient
    {
        IEnumerable<string> GetWords();
    }
}
