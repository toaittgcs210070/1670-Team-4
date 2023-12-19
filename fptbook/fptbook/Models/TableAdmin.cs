using System;
using System.Collections.Generic;

namespace fptbook.Models;

public partial class TableAdmin
{
    public string AdminId { get; set; } = null!;

    public string AdminPassword { get; set; } = null!;

    public string AdminName { get; set; } = null!;

    public string? AdminPhoto { get; set; }

    public string? AdminAddress { get; set; }

    public string? AdminPhone { get; set; }

    public string? AdminEmail { get; set; }
}
