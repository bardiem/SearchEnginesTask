using SearchEnginesTask.Models;
using System.Collections.Generic;
using System.Linq;

namespace SearchEnginesTask.Repository
{
    public class SearchResultRepository : ISearchResultRepository
    {
        private readonly SearchDBContext _dbContext;

        public SearchResultRepository(SearchDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(SearchResult searchResult)
        {
            var result = _dbContext.SearchResults.Add(searchResult);
            _dbContext.SaveChanges();
            return result != null;
        }

        public void CreateMany(IEnumerable<SearchResult> searchResults)
        {
            _dbContext.SearchResults.AddRange(searchResults);
            _dbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            _dbContext.SearchResults.Remove(Get(id));
            _dbContext.SaveChanges();
        }

        public SearchResult Get(long id)
        {
            return _dbContext.SearchResults
                .Where(r => r.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<SearchResult> Get(IEnumerable<string> keyPhrases)
        {
            //var result = _dbContext.SearchResults
            //  .Select(r => new
            //  {
            //      Id = r.Id,
            //      Title = r.Title.Split(' ')
            //    })
            //      .Where(r => r.Title.Split(" ").ToList().Any(w => keyPhrases.ToList().Contains(w));
            //});
            return new List<SearchResult>();
        }

        
    }
}
