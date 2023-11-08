using System.Text.Json.Serialization;

namespace Library_Administration.Models
{
    public class Authors
    {
        public Guid IdAuthor { get; set; }
        public string AuthorName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Books> Books { get; set; }
    }
}
