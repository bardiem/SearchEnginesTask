using SearchEnginesTask.Models;
using System.Collections.Generic;
using System.Linq;


namespace SearchEnginesTask.Services
{
    public interface IStoreResultsService 
    {
        KeyPhrase GetKeyPhrase(string phrase);
        IEnumerable<KeyPhrase> CreatePhrases(IEnumerable<string> keyPhrases);
        IEnumerable<KeyPhrase> CreatePhrases(IEnumerable<KeyPhrase> keyPhrases);
        void CreateSearchResults(IEnumerable<SearchResult> searchResults);
        SearchResult GetSearchResult(string link);
        IEnumerable<SearchResult> GetSearchResults(IEnumerable<string> keyPhrases);

    }
}
