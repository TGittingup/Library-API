using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly List<Book> _books = new();

        [HttpGet]
        public IActionResult GetAll() => Ok(_books);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book is null) return NotFound("Book not found.");
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book updatedBook)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book is null) return NotFound("Book not found.");

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Isbn = updatedBook.Isbn;
            book.Year = updatedBook.Year;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book is null) return NotFound("Book not found.");

            _books.Remove(book);
            return NoContent();
        }
    }
}
