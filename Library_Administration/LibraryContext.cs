using Library_Administration.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Administration
{
    public class LibraryContext : DbContext
    {
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Authors> authorsInit = new List<Authors>();
            authorsInit.Add(new Authors() { IdAuthor = Guid.Parse("9fa56c10-af8b-4672-9386-5c8e5a340179"), AuthorName = "Gabriel Garcia Marquez" });
            authorsInit.Add(new Authors() { IdAuthor = Guid.Parse("fbf4631c-5342-4e96-9408-ee90529dce52"), AuthorName = "Rafael Pombo" });


            modelBuilder.Entity<Authors>(author =>
            {
                author.ToTable("Authors");

                author.HasKey(Item => Item.IdAuthor);

                author.Property(Item => Item.AuthorName).IsRequired().HasMaxLength(150);

                author.HasData(authorsInit);
            });

            List<Books> booksInit = new List<Books>();
            booksInit.Add(new Books() { IdBook = Guid.Parse("1fefd9ce-f57e-420b-bb8d-92f5d73754db"), IdAuthor = Guid.Parse("9fa56c10-af8b-4672-9386-5c8e5a340179"), Title = "Cien años de soledad", YearPublication = 1967 });
            booksInit.Add(new Books() { IdBook = Guid.Parse("131b1c4b-e414-4d41-aaf2-1a3fb52dc20a"), IdAuthor = Guid.Parse("9fa56c10-af8b-4672-9386-5c8e5a340179"), Title = "Del amor y otros demonions", YearPublication = 1994 });
            booksInit.Add(new Books() { IdBook = Guid.Parse("7ab466b4-ba61-41c4-bb91-9c107a669273"), IdAuthor = Guid.Parse("fbf4631c-5342-4e96-9408-ee90529dce52"), Title = "La pobre viejecita", YearPublication = 1854 });
            booksInit.Add(new Books() { IdBook = Guid.Parse("5a960107-9a86-4509-ba11-02af58fddabc"), IdAuthor = Guid.Parse("fbf4631c-5342-4e96-9408-ee90529dce52"), Title = "El renacuajo paseador", YearPublication = 1867 });




            modelBuilder.Entity<Books>(book =>
            {
                book.ToTable("Books");

                book.HasKey(Item => Item.IdBook);

                book.HasOne(Item => Item.Author).WithMany(Item => Item.Books).HasForeignKey(Item => Item.IdAuthor);

                book.Property(Item => Item.Title).IsRequired().HasMaxLength(150);

                book.Property(Item => Item.YearPublication).IsRequired();

                book.HasData(booksInit);

            });
        }
    }
}
