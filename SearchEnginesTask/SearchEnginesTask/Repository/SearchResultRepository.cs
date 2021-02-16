using SearchEnginesTask.Models;
using System.Collections.Generic;
using System.Linq;
using SearchEnginesTask.Services;
using System;

namespace SearchEnginesTask.Repository
{
    public class SearchResultRepository : ISearchResultRepository
    {
        private readonly SearchDBContext _dbContext;
        private readonly IKeyPhraseRepository _keyPhraseRepo;
        private readonly ILocalSearchEngineService _localEngineService;


        public SearchResultRepository(SearchDBContext dbContext,
            IKeyPhraseRepository keyPhraseRepo, 
            ILocalSearchEngineService engineService)
        {
            _dbContext = dbContext;
            _keyPhraseRepo = keyPhraseRepo;
            _localEngineService = engineService;
        }

        public bool Create(SearchResult searchResult)
        {
            return CreateRecord(searchResult)!=null;
        }

        public void CreateMany(IEnumerable<SearchResult> searchResults)
        {
            foreach(var result in searchResults)
            {
                var phrases = _localEngineService.GetKeyPhrasesFromQuery(result.Title);

                var resultInDb = CreateOrRewrite(result);

                var createPhrases = _keyPhraseRepo.CreateMany(phrases);

                foreach(var phrase in createPhrases)
                {
                    var isPhraseOfResultExists = _dbContext.PhrasesOfResults
                        .Where(pr=>pr.PhraseId==phrase.Id && pr.ResultId == resultInDb.Id);

                    if(isPhraseOfResultExists.Count() == 0)
                        _dbContext.PhrasesOfResults.Add(new PhrasesOfResult
                        {
                            Phrase = phrase,
                            PhraseId = phrase.Id,
                            Result = resultInDb,
                            ResultId = resultInDb.Id
                        });
                }
            }
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
            var similarPhrases = _dbContext.KeyPhrases
                .Where(k => keyPhrases.ToList().Contains(k.Phrase))
                .ToList();

            var result = _dbContext.PhrasesOfResults
                .Where(p => similarPhrases.Contains(p.Phrase))
                .Select(p => p.Result)
                .ToList();
                
            return result;
        }

        public SearchResult GetByLink(string link)
        {
            return _dbContext.SearchResults
                .Where(r => r.Link == link)
                .FirstOrDefault();
        }

        private SearchResult CreateRecord(SearchResult searchResult)
        {
            var result = _dbContext.SearchResults.Add(searchResult);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        private SearchResult RewriteRecordByLink(SearchResult searchResult)
        {
            var recordInDb = GetByLink(searchResult.Link);
            if (recordInDb == null)
                throw new Exception(@"Record with this link doesn't exist");

            recordInDb.DisplayLink = searchResult.DisplayLink;
            recordInDb.Snippet = searchResult.Snippet;
            recordInDb.Title = searchResult.Title;

            _dbContext.SaveChanges();
            return recordInDb;
        }

        private SearchResult CreateOrRewrite(SearchResult searchResult)
        {
            var resultRecord = _dbContext.SearchResults
                .Where(r => r.Link == searchResult.Link)
                .FirstOrDefault();
            if (resultRecord != null)
            {
                return RewriteRecordByLink(searchResult);
            }

            return CreateRecord(searchResult);
        }
    }
}
