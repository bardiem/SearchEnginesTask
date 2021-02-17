using System.Collections.Generic;
using SearchEnginesTask.Models;

namespace SearchEnginesTask.Services
{
    public interface IStoreResultsHelper
    {
        IEnumerable<string> GetKeyPhrasesFromQuery(string query);
    }
}
