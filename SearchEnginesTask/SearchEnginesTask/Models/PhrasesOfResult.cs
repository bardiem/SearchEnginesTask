using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SearchEnginesTask.Models
{
    public partial class PhrasesOfResult
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("phraseId")]
        public long PhraseId { get; set; }
        [Column("resultId")]
        public long ResultId { get; set; }

        [ForeignKey(nameof(PhraseId))]
        [InverseProperty(nameof(KeyPhrase.PhrasesOfResults))]
        public virtual KeyPhrase Phrase { get; set; }
        [ForeignKey(nameof(ResultId))]
        [InverseProperty(nameof(SearchResult.PhrasesOfResults))]
        public virtual SearchResult Result { get; set; }
    }
}
