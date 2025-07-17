using LibraryApi.Controllers;
using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;


namespace LibraryApi.Services
{
    public class AdminService
    {
        private readonly LibraryContext _context;
        private static AdminsController adminsController;
        private static List<Admin> adminList;
        public static int _nextId = 1;
        private static readonly object _lock = new object();
        private static bool _isInitialized = false;



        public AdminService(LibraryContext context)
        {
            _context = context;
        }

        public static async Task<List<Admin>> GetAdminList(LibraryContext _context)
        {
            return adminList = await _context.Admins.ToListAsync();
        }



        private static bool IsUsernameTaken(string username)
        {
            return adminList.Any(user => user.Name == username);
        }
        public static async Task<bool> AddUser(Admin user, LibraryContext _context)
        {
            if (!IsUsernameTaken(user.Name))
            {

                try
                {
                    await _context.Admins.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateException)
                {
                    return false;
                }

            }
            else { return false; }

        }

        public static async Task<bool> SignInCheck(Admin admin, LibraryContext _context)
        {
            if (await _context.Admins.AnyAsync(a => a.Name == admin.Name && a.Password == admin.Password))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
