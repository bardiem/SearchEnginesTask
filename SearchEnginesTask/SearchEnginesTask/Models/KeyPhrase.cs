using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SearchEnginesTask.Models
{
    public partial class KeyPhrase
    {
        public KeyPhrase()
        {
            PhrasesOfResults = new HashSet<PhrasesOfResult>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("phrase")]
        [StringLength(100)]
        public string Phrase { get; set; }

        [InverseProperty(nameof(PhrasesOfResult.Phrase))]
        public virtual ICollection<PhrasesOfResult> PhrasesOfResults { get; set; }
    }
}
