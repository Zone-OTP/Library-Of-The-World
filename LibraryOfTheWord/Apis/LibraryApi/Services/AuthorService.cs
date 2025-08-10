using LibraryApi.Data;
using LibraryApi.Models;
using LibraryErrorLogs;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Services
{
    public class AuthorService
    {
        private static List<Author> authorList;
        private readonly LibraryContext _context;
        private readonly static ILoggerService _logger = new LoggerService("AuthorServiceBackEnd");

        public AuthorService(LibraryContext context)
        {
            _context = context;
        }



        public static async Task<List<Author>> GetAuthors(LibraryContext _context)
        {

            return authorList = await _context.Authors.ToListAsync();
        }

        public static async Task<bool> DoesAuthorExists(string authorName, LibraryContext _context)
        {

            return await _context.Authors.AnyAsync(a => a.Name.Trim() == authorName.Trim());
        }

        public static async Task<bool> AddAuthor(Author author, LibraryContext _context)
        {

            Console.WriteLine($"Attempting to add author '{author.Name}'");
            if (!await DoesAuthorExists(author.Name, _context))
            {
                try
                {
                    author.AuthorId = 0;
                    await _context.Authors.AddAsync(author);
                    await _context.SaveChangesAsync();
                    await _logger.LogInformation($"Author '{author.Name}' added successfully.");
                    return true;
                }
                catch (DbUpdateException ex)
                {
                    await _logger.LogError(ex, $"Error adding author: {ex.Message}");
                    return false;
                }
            }
            else
            {
                await _logger.LogInformation($"Author '{author.Name}' already exists.");
                return false;
            }


        }


        public static async Task<Author> GetAuthorById(int authorId, LibraryContext _context)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
        }

        public static async Task<Author> GetAuthorIdByName(string authorName, LibraryContext _context)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Name == authorName);
        }
    }
}
