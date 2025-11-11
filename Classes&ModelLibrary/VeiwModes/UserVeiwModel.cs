namespace Classes_ModelLibrary.VeiwModes
{
    public class UserVeiwModel
    {
        public int CustomerId { get; set; } = 0;
        public string Name { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PersonalGovernmentId { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        public int LibraryCardNumber { get; set; } = 0;

    }
}
