using Library_Administration.Models;

namespace Library_Administration.Servicios
{
    public class BookService : IBooksService
    {
        LibraryContext context;

        public BookService(LibraryContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Books> Get()
        {
            return context.Books;
        }

        public Books GetId(Guid id)
        {
            return context.Books.FirstOrDefault(l => l.IdBook == id);
        }


        public void Save(Books books)
        {
            context.Add(books);
            context.SaveChanges();
        }

        public void Update(Guid id, Books books)
        {
            var bookActual = context.Books.Find(id);

            if (bookActual != null)
            {
                bookActual.Title = books.Title;
                bookActual.YearPublication = books.YearPublication;

                context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            var bookActual = context.Books.Find(id);

            if (bookActual != null)
            {
                context.Remove(bookActual);
                context.SaveChanges();
            }
        }
    }
    public interface IBooksService
    {
        IEnumerable<Books> Get();
        Books GetId(Guid id);
        void Save(Books books);
        void Update(Guid id, Books books);
        void Delete(Guid id);
    }
}
