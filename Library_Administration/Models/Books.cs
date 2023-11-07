namespace Library_Administration.Models
{
    public class Books
    {
        public Guid IdBook { get; set; }
        public Guid IdAuthor { get; set; }
        public string Title { get; set; }
        public int YearPublication { get; set; }
        public Authors Author { get; set; }
    }
}
