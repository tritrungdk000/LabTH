namespace Book.Models.DTO
{
    public class AddPublisherRequestDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PublisherID { get; set; }
        public List<Book> Books { get; set; }

    }
}
