using Library_Administration.Models;

namespace Library_Administration.Servicios
{
    public class AuthorService : IAuthorService
    {
        LibraryContext context;

        public AuthorService(LibraryContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Authors> Get()
        {
            return context.Authors;
        }

        public void SaveAuthor(Authors authors)
        {
            context.Add(authors);
            context.SaveChanges();
        }

        public void UpdateAuthor(Guid id, Authors authors)
        {
            var authorsActual = context.Authors.Find(id);

            if (authorsActual != null)
            {
                authorsActual.AuthorName = authors.AuthorName;

                context.Update(authorsActual);
                context.SaveChanges();
            }
        }

        public void DeleteAuthor(Guid id)
        {
            var authorsActual = context.Authors.Find(id);

            if (authorsActual != null)
            {
                context.Remove(authorsActual);
                context.SaveChanges();
            }
        }
    }
    public interface IAuthorService
    {
        IEnumerable<Authors> Get();
        void SaveAuthor(Authors authors);
        void UpdateAuthor(Guid id, Authors authors);
        void DeleteAuthor(Guid id);
    }
}
