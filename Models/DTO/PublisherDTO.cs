using System.ComponentModel.DataAnnotations;

namespace Book.Models.DTO
{
    public class PublisherDTO
    {

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int PublisherID { get; set; }
        public List<Book> Books { get; set; }
        public List<string> AuthorNames { get; set; }
    }
}

