namespace LibraryOfClasses.VeiwModes
{
    public class CustomerCheckoutViewModel
    {
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CheckoutDate { get; set; }
        public double FineAmount { get; set; }
        public int DaysTakenOut { get; set; }
    }
}
