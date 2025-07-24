namespace LibraryOfClasses.VeiwModes
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int AmountInLibrary { get; set; }
        public int TotalAmountInLibrary { get; set; }
        public List<string> TakenByCustomerNames { get; set; } = new List<string>();
        public List<int> CustomerId { get; set; }

    }
}
