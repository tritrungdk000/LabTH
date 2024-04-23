using System.ComponentModel.DataAnnotations;

namespace Book
{
    public class Authors
    {
        [Key]
        public int   Id { get; set; }
        public string FullName { get; set; }

        // One-to-many relationship with books
        public List<Book_Author>? Book_Author { get; set; }
    }
}