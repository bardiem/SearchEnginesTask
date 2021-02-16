using SearchEnginesTask.Models;
using System.Collections.Generic;

namespace SearchEnginesTask.Repository
{
    public interface ISearchResultRepository
    {
        bool Create(SearchResult searchResult);
        void CreateMany(IEnumerable<SearchResult> searchResults);
        void Delete(long id);
        SearchResult Get(long id);
        IEnumerable<SearchResult> Get(IEnumerable<string> keyPhrases);

    }
}
