using System.ComponentModel.DataAnnotations;

namespace Book
{
    public class Publishers
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        // One-to-many relationship with books
       
        public List<Book>? Book { get; set; }
        
    }
}