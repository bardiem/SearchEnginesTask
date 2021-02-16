using SearchEnginesTask.Models;
using System.Collections.Generic;

namespace SearchEnginesTask.Repository
{
    interface IKeyPhraseRepository
    {
        bool Create(KeyPhrase keyPhrase);
        void CreateMany(IEnumerable<KeyPhrase> keyPhrases);
        void Delete(long id);
        KeyPhrase Get(long id);
        KeyPhrase Get(string phrase);
    }
}
