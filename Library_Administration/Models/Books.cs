using System.Text.Json.Serialization;

namespace Library_Administration.Models
{
    public class Books
    {
        public Guid IdBook { get; set; }
        public Guid IdAuthor { get; set; }
        public string Title { get; set; }
        public int YearPublication { get; set; }

        [JsonIgnore]
        public Authors Author { get; set; }
    }
}
