using System.Text;
using System.Text.Json;
using LibraryErrorLogs;
using LibraryOfClasses.Classes;
using LibraryOfClasses.VeiwModes;



namespace LibraryOfTheWorld.Services
{
    public class AuthorService
    {

        
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5160") };
        private static List<Author> authorList;
        private static readonly ILoggerService _logger = new LoggerService("AuthorServiceFrontEnd");
        static AuthorService()
        {
        }


        public static async Task<List<Author>> LoadAuthors()
        {
            try
            {
                var endpoint = $"/api/authors";
                HttpResponseMessage response = await client.GetAsync(endpoint);
                string json = await response.Content.ReadAsStringAsync();
                authorList = JsonSerializer.Deserialize<List<Author>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                });
                response.EnsureSuccessStatusCode();
                return authorList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching Authors from API: {ex.Message}");
                return new List<Author>();
            }
        }


        public static async Task<bool> DoesAuthorExists(string authorName)
        {
            var endpoint = $"/api/authors/authorCheck/{authorName}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<bool>(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking existence: {ex.Message}");
                return false;
            }
        }

        public static async Task<Author> AddAuthor(string authorName)
        {
            var endpoint = $"/api/authors/";
            Author author = new Author(authorName);
            try
            {
                string jsonAuthor = JsonSerializer.Serialize(author);
                var content = new StringContent(jsonAuthor, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                Author createdEntity = JsonSerializer.Deserialize<Author>(responseJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true, WriteIndented = true });
                return createdEntity;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error posting Authors to API: {ex.Message}");
                return null;
            }
        }


        public static async Task<Author> GetAuthorByName(string authorName)
        {
            try
            {
                int authorId = await GetAuthorIdByName(authorName);
                if (authorId != 0)
                {
                    return await GetAuthorById(authorId);

                }
                else { throw new Exception("Author not found"); }
            }
            catch (Exception ex) { Console.WriteLine($"{ex}"); return null; }


        }

        public static async Task<Author> GetAuthorById(int id)
        {
            string endpoint = $"/api/authors/getauthorspecial/{id}/null";
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                string json = await response.Content.ReadAsStringAsync();
                Author author = JsonSerializer.Deserialize<Author>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                });
                response.EnsureSuccessStatusCode();
                return author;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error at Author Serivece" + ex.Message);
                return null;
            }
        }

        public static async Task<string> GetAuthorNameById(int authorId)
        {
            var author = await GetAuthorById(authorId);
            return author.Name != null ? author.Name : "Unknown Author";
        }

        public static async Task<int> GetAuthorIdByName(string authorName)
        {
            string endpoint = $"/api/authors/getauthorspecial/0/{authorName}";
            try
            {
                HttpResponseMessage response = await client.GetAsync(endpoint);
                string json = await response.Content.ReadAsStringAsync();
                Author author = JsonSerializer.Deserialize<Author>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    IncludeFields = true,
                });
                response.EnsureSuccessStatusCode();
                return author.AuthorId;
            }
            catch (Exception ex)
            {
                await _logger.LogError(ex, "Error at Author Service" + ex.Message);
                return 0;
            }
        }
    }
}
