using System;
using System.Collections.Generic;

namespace LibraryApi.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string PersonalGovermentId { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int LibraryCardNumber { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();

    public virtual ICollection<PasswordReset> PasswordResets { get; set; } = new List<PasswordReset>();
}
