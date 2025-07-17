using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await BookService.GetBooks(_context);
        }

        [HttpGet("getbook/{bookId}")]
        public async Task<ActionResult<Book>> GetBook(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("bookcheck/{bookName}/{authorId}")]

        public async Task<bool> DoesBookExist(string bookName, int authorId)
        {
            return await BookService.IsBookInLibrary(bookName, authorId, _context);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {

            if (await BookService.AddNewBook(book, _context))
            {
                return Created($"/api/books/{book.BookId}", book);
            }
            else
            {
                return Conflict("Unkown Error");
            }

        }

        [HttpPatch("removeonebook/{bookId}")]
        public async Task<ActionResult<Book>> RemoveBook(int bookId)
        {
            if (await BookService.RemoveBook(bookId, _context))
            {
                return Ok("We Removed the Book");
            }
            else { return Conflict("coudn't remove book"); }
        }
        [HttpPatch("returnbook/{bookId}/{customerId}")]
        public async Task<IActionResult> ReturnBook(int bookId, int customerId)
        {
            var value = await BookService.ReturnBook(bookId, customerId, _context);
            if (value <= 0.0)
            {
                return Ok("Book Has Been Returned");
            }
            else { return Conflict($"could not return the book,Check For Fine needs to be payed {value}"); }
            ;
        }
        [HttpPatch("takebookout/{bookId}/{customerId}")]
        public async Task<ActionResult<Book>> TakeBookOut(int bookId, int customerId)
        {
            if (await BookService.TakeBookOut(bookId, customerId, _context))
            {

                return Ok("Book Has Been Taken");

            }
            else { return Conflict("coudn't take book out"); }

        }

        [HttpPatch("editbook/{bookId}/{bookNewName}/{authorId}")]

        public async Task<ActionResult<Book>> EditBook(int bookId, string bookNewName, int authorId)
        {
            if (await BookService.EditBook(bookId, bookNewName, authorId, _context))
            {

                return Ok("Compleated");

            }
            else { return Conflict("coudn't edit book"); }

        }

        [HttpDelete("deletebook/{bookId}")]

        public async Task<ActionResult<Book>> RemoveBookByRoot(int bookId)
        {
            if (await BookService.RemoveBookByRoot(bookId, _context))
            {
                return Ok("Book Has Been Removed From Database");
            }
            else { return Conflict("unable to remove Book by root"); }

        }

        [HttpPatch("payfine/{bookId}/{customerId}")]
        public async Task<ActionResult<Book>> payfine(int bookId, int customerId)
        {
            try
            {
                await BookService.PayFine(bookId, customerId, _context);
                return Ok("Thanks for Paying your fine you have returned the book");

            }
            catch (Exception ex) { return Conflict(ex.Message); }
        }
    }
}
