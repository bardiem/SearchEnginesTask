using System.Collections.Generic;
using SearchEnginesTask.Models;

namespace SearchEnginesTask.Services
{
    public interface ILocalSearchEngineService
    {
        IEnumerable<string> GetKeyPhracesFromQuery(string query);
    }
}
