using SearchEnginesTask.Models;
using System.Collections.Generic;
using System.Linq;
using SearchEnginesTask.Models;

namespace SearchEnginesTask.Services
{
    public class LocalSearchEngineService : ILocalSearchEngineService
    {
        private readonly SearchDBContext _dbContext;
        private readonly ILocalSearchEngineService _localSearchService;
        
        public LocalSearchEngineService(ILocalSearchEngineService localSearchService)
        {
            _localSearchService = localSearchService;
        }

        public IEnumerable<SearchResult> SearchCachedData(IEnumerable<string> keyPhrases)
        {
            var result = _dbContext.SearchResults
                .Select(r=> new 
                { 
                    Id=r.Id,
                    Title = r.Title.Split(" ")l
                })
                .Where(r => r.Title.Split(" ").ToList().Any(w => keyPhrases.ToList().Contains(w));
            });
        }
    }
}
