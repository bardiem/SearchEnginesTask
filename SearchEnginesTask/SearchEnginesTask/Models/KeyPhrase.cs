using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SearchEnginesTask.Models
{
    public partial class KeyPhrase
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("phrase")]
        [StringLength(100)]
        public string Phrase { get; set; }
    }
}
