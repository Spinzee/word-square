namespace WordSquare.Services
{
    public class BuildSquareService
    {
        private readonly DictionaryService _dictionary;

        public BuildSquareService(DictionaryService dictionary)
        {
            _dictionary = dictionary;
        }

        public List<string>? Solve(int size, string letters)
        {
            var availableLetters = letters.ToList();
            var square = new List<string>();
            var candidates = _dictionary.GetWordsOfLength(size).ToList();

            TryBuildSquare(size, square, availableLetters, candidates);

            return square;
        }

        private bool TryBuildSquare(
            int size,
            List<string> square,
            List<char> availableLetters,
            List<string> candidates)
        {
            if (square.Count == size)
                return true;

            foreach (var word in candidates)
            {
                if (!CanFormWord(word, availableLetters))
                    continue;

                if (!MatchesExistingRows(square, word))
                    continue;

                PlaceWord(square, availableLetters, word);

                if (TryBuildSquare(size, square, availableLetters, candidates))
                    return true;

                RemoveWord(square, availableLetters, word);
            }

            return false;
        }

        private static bool MatchesExistingRows(List<string> square, string word)
        {
            int rowIndex = square.Count;

            for (int i = 0; i < rowIndex; i++)
            {
                if (square[i][rowIndex] != word[i])
                    return false;
            }

            return true;
        }

        private static bool CanFormWord(string word, List<char> availableLetters)
        {
            var lettersCopy = new List<char>(availableLetters);

            foreach (var letter in word)
            {
                if (!lettersCopy.Remove(letter))
                    return false;
            }

            return true;
        }

        private static void PlaceWord(
            List<string> square,
            List<char> availableLetters,
            string word)
        {
            square.Add(word);

            foreach (var letter in word)
                availableLetters.Remove(letter);
        }

        private static void RemoveWord(
            List<string> square,
            List<char> availableLetters,
            string word)
        {
            square.RemoveAt(square.Count - 1);
            availableLetters.AddRange(word);
        }
    }
}