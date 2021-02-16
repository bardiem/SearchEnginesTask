using Microsoft.EntityFrameworkCore;



namespace SearchEnginesTask.Models
{
    public partial class SearchDBContext : DbContext
    {
        public SearchDBContext()
        {
            Database.EnsureCreated();
        }

        public SearchDBContext(DbContextOptions<SearchDBContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<KeyPhrase> KeyPhrases { get; set; }
        public virtual DbSet<SearchResult> SearchResults { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<KeyPhrase>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.SearchResult)
                    .WithMany(p => p.KeyPhrases)
                    .HasForeignKey(d => d.SearchResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KeyPhrases_SearchResults");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
