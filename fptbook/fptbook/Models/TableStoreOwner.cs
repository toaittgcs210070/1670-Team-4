using System;
using System.Collections.Generic;

namespace fptbook.Models;

public partial class TableStoreOwner
{
    public string StoreOwnerId { get; set; } = null!;

    public string StoreOwnerPassword { get; set; } = null!;

    public string StoreOwnerName { get; set; } = null!;

    public string StoreOwnerAddress { get; set; } = null!;

    public string? StoreOwnerPhoto { get; set; }

    public string? StoreOwnerPhone { get; set; }

    public string? StoreOwnerTaxCode { get; set; }

    public string? StoreOwnerDetails { get; set; }

    public string? StoreOwnerEmail { get; set; }

    public virtual ICollection<TableBook> TableBooks { get; set; } = new List<TableBook>();
}
