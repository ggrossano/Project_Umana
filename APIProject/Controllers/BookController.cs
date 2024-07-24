using APIProject.Entities;
using APIProject.Service;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            List<Book> books = bookService.GetAll();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Book book = bookService.GetById(id);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            var createBook = bookService.CreateBook(book);
            return Ok(createBook);
            //return CreatedAtAction(nameof(GetById), new { id = createBook.Id }, createBook);

        }

        [HttpPut]
        public async Task<ActionResult<Book>> UpdateBook(Book book)
        {

            var createBook = bookService.UpdateBook(book);

            return Ok(createBook);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var deletedBook = bookService.DeleteBook(id);
            return Ok(deletedBook);
        }

    }
}