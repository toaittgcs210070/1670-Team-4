using System;
using System.Collections.Generic;

namespace fptbook.Models;

public partial class TablePublisher
{
    public string PublisherId { get; set; } = null!;

    public string PublisherName { get; set; } = null!;

    public string? PublisherAddress { get; set; }

    public string? PublisherLogo { get; set; }

    public string? PublisherDetail { get; set; }

    public virtual ICollection<TableBook> TableBooks { get; set; } = new List<TableBook>();
}
