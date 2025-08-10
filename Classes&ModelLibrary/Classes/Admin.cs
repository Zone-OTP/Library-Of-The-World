using System.ComponentModel.DataAnnotations;

namespace LibraryOfClasses.Classes
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        private static int _nextId = 1;

        public Admin() { }
        public Admin(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
