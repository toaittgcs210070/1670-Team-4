using System;
using System.Collections.Generic;

namespace fptbook.Models;

public partial class TableAuthor
{
    public string AuthorId { get; set; } = null!;

    public string AuthorName { get; set; } = null!;

    public string? AuthorAddress { get; set; }

    public string? AuthorEmail { get; set; }

    public string? AuthorPhoto { get; set; }

    public string? AuthorDetail { get; set; }

    public virtual ICollection<TableBook> TableBooks { get; set; } = new List<TableBook>();
}
