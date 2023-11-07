namespace Library_Administration.Models
{
    public class Authors
    {
        public Guid IdAuthor { get; set; }
        public string AuthorName { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}
