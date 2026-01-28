using System.ComponentModel;
using WordSquare.Services;
using WordSquareTests.Fakes;

namespace WordSquareTests.Services
{
    public class DictionaryServiceTests
    {        
        [Fact, Description(
            "GIVEN length" +
            "THEN return list of words of correct length")]
        public void GetWordsOfLength_ReturnExpected()
        {
            var dictionaryClient = new FakeDictionaryClient();

            var dictionaryService = new DictionaryService(dictionaryClient); 

            var words = dictionaryService.GetWordsOfLength(3);

            Assert.Equal(4, words?.Count());
            Assert.Equal("cat", words?.First());
            Assert.Equal("rat", words?.Last());
        }
    }
}
