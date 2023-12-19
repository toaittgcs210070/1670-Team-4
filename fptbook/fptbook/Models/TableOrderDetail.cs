using System;
using System.Collections.Generic;

namespace fptbook.Models;

public partial class TableOrderDetail
{
    public int OrderId { get; set; }

    public string BookId { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual TableBook Book { get; set; } = null!;

    public virtual TableOrder Order { get; set; } = null!;
}
