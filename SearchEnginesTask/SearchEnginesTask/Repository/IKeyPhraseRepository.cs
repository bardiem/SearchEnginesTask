using SearchEnginesTask.Models;
using System.Collections.Generic;

namespace SearchEnginesTask.Repository
{
    public interface IKeyPhraseRepository
    {
        bool Create(KeyPhrase keyPhrase);
        IEnumerable<KeyPhrase> CreateMany(IEnumerable<string> keyPhrases);
        IEnumerable<KeyPhrase> CreateMany(IEnumerable<KeyPhrase> keyPhrases);
        void Delete(long id);
        KeyPhrase Get(long id);
        KeyPhrase Get(string phrase);
    }
}
