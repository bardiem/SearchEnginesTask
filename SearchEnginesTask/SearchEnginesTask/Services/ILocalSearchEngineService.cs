using System.Collections.Generic;
using SearchEnginesTask.Models;

namespace SearchEnginesTask.Services
{
    public interface ILocalSearchEngineService
    {
        IEnumerable<SearchResult> SearchCachedData(string[] keyPhrases);
    }
}
