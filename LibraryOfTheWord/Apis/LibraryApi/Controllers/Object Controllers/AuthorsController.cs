using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private readonly LibraryContext _context;

        public AuthorsController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await AuthorService.GetAuthors(_context);
        }
        [HttpGet("authorCheck/{authorName}")]

        public async Task<bool> AuthorExists(string authorName)
        {
            return await AuthorService.DoesAuthorExists(authorName, _context);
        }

        [HttpGet("getauthorspecial/{authorId}/{authorName}")]
        public async Task<ActionResult<Author>> GetAuthorSpecial(int authorId, string authorName)
        {
            if (authorId != 0)
            {
                var author = await AuthorService.GetAuthorById(authorId, _context);
                return Ok(author);
            }
            else
            {
                var author = await AuthorService.GetAuthorIdByName(authorName, _context);
                return Ok(author);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            if (await AuthorService.AddAuthor(author, _context))
            {
                return Created($"/api/authors/{author.AuthorId}", author);
            }
            else { return Conflict("Author Allready exists"); }
        }

    }
}
