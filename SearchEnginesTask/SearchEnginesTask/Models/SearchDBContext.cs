using Microsoft.EntityFrameworkCore;


namespace SearchEnginesTask.Models
{
    public partial class SearchDBContext : DbContext
    {
        public SearchDBContext(){}

        public SearchDBContext(DbContextOptions<SearchDBContext> options): base(options)
        {
            Database.EnsureCreated();
        }


        public virtual DbSet<SearchResult> SearchResults { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
