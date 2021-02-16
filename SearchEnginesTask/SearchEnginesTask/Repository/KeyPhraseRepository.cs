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

        public bool Create(KeyPhrase keyPhrase)
        {
            var result = _dbContext.KeyPhrases.Add(keyPhrase);
            _dbContext.SaveChanges();
            return result != null;
        }

        public void CreateMany(IEnumerable<KeyPhrase> keyPhrases)
        {
            throw new NotImplementedException();
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
            return _dbContext.KeyPhrases.Where(k => k.Phrase == phrase).FirstOrDefault();
        }
    }
}
