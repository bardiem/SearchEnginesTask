using SearchEnginesTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SearchEnginesTask.Repository;

namespace SearchEnginesTask.Services
{
    public class StoreResultsService : IStoreResultsService
    {
        private readonly IGenericRepository<KeyPhrase> _keyPhraseRepo;
        private readonly IGenericRepository<SearchResult> _searchResultRepo;
        private readonly IGenericRepository<PhrasesOfResult> _phrasesOfResultRepo;
        private readonly IStoreResultsHelper _storeHelper;

        public StoreResultsService(IStoreResultsHelper storeHelper, 
            IGenericRepository<KeyPhrase> keyPhraseRepo, 
            IGenericRepository<SearchResult> searchResultRepo, 
            IGenericRepository<PhrasesOfResult> phrasesOfResultRepo)
        {
            _storeHelper = storeHelper;
            _keyPhraseRepo = keyPhraseRepo;
            _searchResultRepo = searchResultRepo;
            _phrasesOfResultRepo = phrasesOfResultRepo;
        }


        public IEnumerable<KeyPhrase> CreatePhrases(IEnumerable<string> keyPhrases)
        {
            var newPhrases = keyPhrases.Select(k => new KeyPhrase { Phrase = k });
            return CreatePhrases(newPhrases);
        }


        public IEnumerable<KeyPhrase> CreatePhrases(IEnumerable<KeyPhrase> keyPhrases)
        {
            var createdRecords = new List<KeyPhrase>();
            foreach (var phrase in keyPhrases)
            {
                var createdRecord = CreateWithoutDuplicates(phrase);
                if (createdRecord != null)
                    createdRecords.Add(createdRecord);
            }

            return createdRecords;
        }


        public void CreateSearchResults(IEnumerable<SearchResult> searchResults)
        {
            foreach (var result in searchResults)
            {
                var phrases = _storeHelper.GetKeyPhrasesFromQuery(result.Title);

                var resultInDb = CreateOrRewrite(result);

                var createdPhrases = CreatePhrases(phrases);

                foreach (var phrase in createdPhrases)
                {
                    var isPhraseOfResultExists = _phrasesOfResultRepo.Get(pr => pr.PhraseId == phrase.Id && pr.ResultId == resultInDb.Id);

                    if (isPhraseOfResultExists.Count() == 0)
                        _phrasesOfResultRepo.Create(new PhrasesOfResult
                        {
                            Phrase = phrase,
                            PhraseId = phrase.Id,
                            Result = resultInDb,
                            ResultId = resultInDb.Id
                        });
                }
            }
          
        }


        public KeyPhrase GetKeyPhrase(string phrase)
        {
            return _keyPhraseRepo.Get(k => k.Phrase == phrase)
                .FirstOrDefault();
        }


        public IEnumerable<SearchResult> GetSearchResults(IEnumerable<string> keyPhrases)
        {
            var similarPhrases = _keyPhraseRepo
                .Get(k => keyPhrases.ToList().Contains(k.Phrase))
                .ToList();

            var result = _phrasesOfResultRepo
                .Get(p => similarPhrases.Contains(p.Phrase))
                .Select(p => p.Result)
                .ToList();

            return result;
        }


        public SearchResult GetSearchResult(string link)
        {
            return _searchResultRepo
                .Get(r => r.Link == link)
                .FirstOrDefault();
        }


        private KeyPhrase CreateWithoutDuplicates(KeyPhrase keyPhrase)
        {
            try
            {
                var phrase = GetKeyPhrase(keyPhrase.Phrase);
                if (phrase != null)
                    return phrase;
                var createdPhrase = _keyPhraseRepo.Create(keyPhrase);
                return createdPhrase;
            }
            catch (Exception)
            {
                return null;
            }

        }


        private SearchResult RewriteRecordByLink(SearchResult searchResult)
        {
            var recordInDb = GetSearchResult(searchResult.Link);
            if (recordInDb == null)
                throw new ArgumentException(@"Record with this link doesn't exist");

            searchResult.Id = recordInDb.Id;
            _searchResultRepo.Update(searchResult);

            return recordInDb;
        }


        private SearchResult CreateOrRewrite(SearchResult searchResult)
        {
            var resultRecord = _searchResultRepo
                .Get(r => r.Link == searchResult.Link)
                .FirstOrDefault();

            if (resultRecord != null)
            {
                return RewriteRecordByLink(searchResult);
            }

            return _searchResultRepo.Create(searchResult);
        }
    }
}
