using System;
using System.Collections.Generic;

namespace LibraryApi.Models;

public partial class PasswordReset
{
    public int PasswordResetId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
