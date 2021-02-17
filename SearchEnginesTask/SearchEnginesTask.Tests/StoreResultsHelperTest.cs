using SearchEnginesTask.Services;
using Xunit;


namespace SearchEnginesTask.Tests
{
    public class StoreResultsHelperTest
    {
        [Theory]
        [InlineData("", null)]
        [InlineData("youtube.com f", new string[] { "youtube.com", "youtube.com f" })]
        [InlineData("three words goes", new string[] { "three", "words", "goes" })]
        public void GetKeyPhrasesFromQuery_WorksCorrectly(string query, string[] result)
        {

            IStoreResultsHelper engineService = new StoreResultsHelper();
            var expected = engineService.GetKeyPhrasesFromQuery(query);

            Assert.Equal(expected, result);

        }
    }
}
