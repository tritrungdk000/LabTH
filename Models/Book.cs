using Book;
using System.ComponentModel.DataAnnotations;

namespace Book
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public  string Genre { get; set; }
        public string? CoverUrl { get; set; }    
        public DateTime DateAdded { get; set; }

        // One-to-many relation with author
        public int  PublisherID { get; set; }
        public Publishers Publishers { get; set; }
        public List <Book_Author> Books_Author { get; set;}
    }
}