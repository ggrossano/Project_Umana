using System.Text.Json.Serialization;

namespace APIProject.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Year { get; set; }

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }
        [JsonIgnore]
        public Author? Author { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; } 

    }
}