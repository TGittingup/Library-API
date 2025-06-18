namespace LibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
// This code defines a Book class with properties for Id, Title, Author, Isbn, and Year.