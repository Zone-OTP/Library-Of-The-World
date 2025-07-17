using System.Text;
using System.Text.Json;
using LibraryOfTheWorld.Classes;
using LibraryOfTheWorld.DattaHandlers;

namespace LibraryOfTheWorld.Services
{
    public class AdminService
    {
        private static DataHandler dataHandler = new DataHandler();
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5160") };

        static AdminService()
        {
        }

        public static async Task<bool> SignInCheck(string username, string password)
        {
            string endpoint = $"/api/admins/Validate";
            try
            {
                Admin admin = new Admin(username, password);
                string jsonAdmin = JsonSerializer.Serialize(admin);
                var content = new StringContent(jsonAdmin, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                NotificationService.ShowMessage($"Exeption thrown {ex}");
                return false;
            }
        }
    }
}
