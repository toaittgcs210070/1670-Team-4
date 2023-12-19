using System;
using System.Collections.Generic;

namespace fptbook.Models;

public partial class TableCustomer
{
    public string CustomerEmail { get; set; } = null!;

    public string CustomerPassword { get; set; } = null!;

    public string CustomerFullName { get; set; } = null!;

    public string? CustomerPhoto { get; set; }

    public string? CustomerAddress { get; set; }

    public string? CustomerPhone { get; set; }

    public virtual ICollection<TableOrder> TableOrders { get; set; } = new List<TableOrder>();
}
