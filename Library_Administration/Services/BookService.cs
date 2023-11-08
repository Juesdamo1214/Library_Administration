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

        public Books GetByIdBook(Guid id)
        {
            return context.Books.FirstOrDefault(item => item.IdBook == id);
        }


        public void SaveBook(Books books)
        {
            context.Add(books);
            context.SaveChanges();
        }

        public void UpdateBook(Guid id, Books books)
        {
            var bookActual = context.Books.Find(id);

            if (bookActual != null)
            {
                bookActual.Title = books.Title;
                bookActual.YearPublication = books.YearPublication;
                context.Update(bookActual);
                context.SaveChanges();
            }
        }

        public void DeleteBook(Guid id)
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
        Books GetByIdBook(Guid id);
        void SaveBook(Books books);
        void UpdateBook(Guid id, Books books);
        void DeleteBook(Guid id);
    }
}
