using Microsoft.EntityFrameworkCore;



namespace SearchEnginesTask.Models
{
    public partial class SearchDBContext : DbContext
    {
        public SearchDBContext()
        {
            Database.EnsureCreated();
        }

        public SearchDBContext(DbContextOptions<SearchDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<KeyPhrase> KeyPhrases { get; set; }
        public virtual DbSet<PhrasesOfResult> PhrasesOfResults { get; set; }
        public virtual DbSet<SearchResult> SearchResults { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<PhrasesOfResult>(entity =>
            {
                entity.HasOne(d => d.Phrase)
                    .WithMany(p => p.PhrasesOfResults)
                    .HasForeignKey(d => d.PhraseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhrasesOfResults_KeyPhrases");

                entity.HasOne(d => d.Result)
                    .WithMany(p => p.PhrasesOfResults)
                    .HasForeignKey(d => d.ResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhrasesOfResults_SearchResults");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
