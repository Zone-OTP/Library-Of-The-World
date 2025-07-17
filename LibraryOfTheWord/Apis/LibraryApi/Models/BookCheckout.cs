using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models;

public partial class BookCheckout
{
    [Key]
    public int BookCheckoutId { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public int BookId { get; set; }

    [Required]
    public DateTime CheckoutDate { get; set; }
}
