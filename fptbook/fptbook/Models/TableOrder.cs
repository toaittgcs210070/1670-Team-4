using System;
using System.Collections.Generic;

namespace fptbook.Models;

public partial class TableOrder
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public int OrderTotal { get; set; }

    public string OrderStatus { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public virtual TableCustomer CustomerEmailNavigation { get; set; } = null!;

    public virtual ICollection<TableOrderDetail> TableOrderDetails { get; set; } = new List<TableOrderDetail>();
}
