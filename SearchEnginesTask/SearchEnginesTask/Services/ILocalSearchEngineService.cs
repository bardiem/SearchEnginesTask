using System.Collections.Generic;
using SearchEnginesTask.Models;

namespace SearchEnginesTask.Services
{
    public interface ILocalSearchEngineService
    {
        IEnumerable<string> GetKeyPhrasesFromQuery(string query);
    }
}
