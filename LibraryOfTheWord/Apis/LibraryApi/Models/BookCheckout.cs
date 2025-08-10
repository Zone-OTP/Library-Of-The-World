using System;
using System.Collections.Generic;

namespace LibraryApi.Models;

public partial class BookCheckout
{
    public int BookCheckoutId { get; set; }

    public int CustomerId { get; set; }

    public int BookId { get; set; }

    public DateTime CheckoutDate { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
