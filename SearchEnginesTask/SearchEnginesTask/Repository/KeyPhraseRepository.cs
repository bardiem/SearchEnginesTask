using SearchEnginesTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchEnginesTask.Repository
{
    public class KeyPhraseRepository : IKeyPhraseRepository
    {

        private readonly SearchDBContext _dbContext;

        public KeyPhraseRepository(SearchDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private KeyPhrase CreateWithoutDuplicates(KeyPhrase keyPhrase)
        {
            try
            {
                var phrase = Get(keyPhrase.Phrase);
                if (phrase != null)
                    return phrase;
                var createdPhrase = _dbContext.Add(keyPhrase);
                _dbContext.SaveChanges();
                return createdPhrase.Entity;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public bool Create(KeyPhrase keyPhrase)
        {
            return CreateWithoutDuplicates(keyPhrase) != null;
        }

        public IEnumerable<KeyPhrase> CreateMany(IEnumerable<string> keyPhrases)
        {
            var newPhrases = keyPhrases.Select(k => new KeyPhrase { Phrase = k });
            return CreateMany(newPhrases);
        }

        public IEnumerable<KeyPhrase> CreateMany(IEnumerable<KeyPhrase> keyPhrases)
        {
            var createdRecords = new List<KeyPhrase>();
            foreach(var phrase in keyPhrases)
            {
                var createdRecord = CreateWithoutDuplicates(phrase);
                if (createdRecord != null)
                    createdRecords.Add(createdRecord);
            }

            return createdRecords;
        }

        public void Delete(long id)
        {
            _dbContext.KeyPhrases.Remove(Get(id));
            _dbContext.SaveChanges();
        }

        public KeyPhrase Get(long id)
        {
            return _dbContext.KeyPhrases.Find(id);
        }

        public KeyPhrase Get(string phrase)
        {
            return _dbContext.KeyPhrases
                .Where(k => k.Phrase == phrase)
                .FirstOrDefault();
        }
    }
}
