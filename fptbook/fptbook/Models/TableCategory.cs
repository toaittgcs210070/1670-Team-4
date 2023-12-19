using System;
using System.Collections.Generic;

namespace fptbook.Models;

public partial class TableCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryDetail { get; set; }

    public virtual ICollection<TableBook> TableBooks { get; set; } = new List<TableBook>();
}
