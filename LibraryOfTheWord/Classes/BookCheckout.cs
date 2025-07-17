using System.ComponentModel.DataAnnotations;

namespace LibraryOfTheWorld.Classes
{
    public class BookCheckout
    {
        [Key]
        public int BookCheckoutId { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public DateTime CheckoutDate { get; set; }
        public Customer Customer { get; set; }
        public Book Book { get; set; }


        public BookCheckout(int customerId, int bookId, Customer customer, Book book)
        {
            CustomerId = customerId;
            BookId = bookId;
            Book = book;
            Customer = customer;
            CheckoutDate = DateTime.Now;
        }

        public BookCheckout() { }
    }
}
