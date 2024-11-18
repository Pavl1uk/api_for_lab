using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static List<Book> books = new List<Book>
    {
        new Book { Id = 1, Title = "1984", Author = "George Orwell" },
        new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee" }
    };

    // GET: api/books
    [HttpGet]
    public IActionResult GetBooks()
    {
        return Ok(books);
    }

    // GET: api/books/{id}
    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
            return NotFound($"Book with Id = {id} not found.");
        return Ok(book);
    }

    // POST: api/books
    [HttpPost]
    public IActionResult AddBook([FromBody] Book newBook)
    {
        newBook.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
        books.Add(newBook);
        return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
    }

    // PUT: api/books/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
            return NotFound($"Book with Id = {id} not found.");

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;

        return NoContent(); // HTTP 204
    }

    // DELETE: api/books/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
            return NotFound($"Book with Id = {id} not found.");

        books.Remove(book);
        return NoContent(); // HTTP 204
    }
}

// Простий клас для книги
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}