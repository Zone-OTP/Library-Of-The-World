using System;
using System.Collections.Generic;

namespace LibraryApi.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Name { get; set; } = null!;

    public int AuthorId { get; set; }

    public int AmountInLibrary { get; set; }

    public int TotalAmountInLibrary { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<BookCheckout> BookCheckouts { get; set; } = new List<BookCheckout>();
}
