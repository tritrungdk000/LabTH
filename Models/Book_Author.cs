using System.ComponentModel.DataAnnotations;

namespace Book
{
    public class Book_Author
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        
        public int AuthorId { get; set; }
        public Authors Author { get; set; }
        

    }
}