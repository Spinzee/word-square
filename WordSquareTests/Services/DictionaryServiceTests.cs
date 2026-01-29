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

        [Fact, Description(
            "GIVEN length" +
            "AND prefix" +
            "THEN return list of words of correct length" +
            "AND prefix")]
        public void GetWordsOfLengthAndPrefix_ReturnExpected()
        {
            var dictionaryClient = new FakeDictionaryClient();

            var dictionaryService = new DictionaryService(dictionaryClient);

            var words = dictionaryService.GetWordsOfLengthAndPrefix(4, "ca");

            Assert.Equal(2, words?.Count());
            Assert.Equal("cake", words?.First());
            Assert.Equal("cars", words?.Last());
        }
    }
}
