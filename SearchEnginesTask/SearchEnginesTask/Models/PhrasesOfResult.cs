using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace SearchEnginesTask.Models
{
    [Keyless]
    public partial class PhrasesOfResult
    {
        [Column("phraseId")]
        public long PhraseId { get; set; }
        [Column("resultId")]
        public long ResultId { get; set; }

        [ForeignKey(nameof(PhraseId))]
        public virtual KeyPhrase Phrase { get; set; }
        [ForeignKey(nameof(ResultId))]
        public virtual SearchResult Result { get; set; }
    }
}
