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

        public void Save(Authors authors)
        {
            context.Add(authors);
            context.SaveChanges();
        }

        public void Update(Guid id, Authors authors)
        {
            var authorsActual = context.Authors.Find(id);

            if (authorsActual != null)
            {
                authorsActual.AuthorName = authors.AuthorName;

                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
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
        void Save(Authors authors);
        void Update(Guid id, Authors authors);
        void Delete(Guid id);
    }
}
