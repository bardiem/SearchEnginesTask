using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SearchEnginesTask.Models
{
    public partial class SearchResult
    {
        public SearchResult()
        {
            PhrasesOfResults = new HashSet<PhrasesOfResult>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("title")]
        [StringLength(500)]
        public string Title { get; set; }
        [Required]
        [Column("link")]
        [StringLength(1000)]
        public string Link { get; set; }
        [Column("displayLink")]
        [StringLength(1000)]
        public string DisplayLink { get; set; }
        [Required]
        [Column("snippet", TypeName = "text")]
        public string Snippet { get; set; }

        [InverseProperty(nameof(PhrasesOfResult.Result))]
        public virtual ICollection<PhrasesOfResult> PhrasesOfResults { get; set; }
    }
}
