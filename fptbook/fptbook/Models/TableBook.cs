using System;
using System.Collections.Generic;

namespace fptbook.Models;

public partial class TableBook
{
    public string BookId { get; set; } = null!;

    public string BookTitle { get; set; } = null!;

    public int CategoryId { get; set; }

    public string AuthorId { get; set; } = null!;

    public string StoreOwnerId { get; set; } = null!;

    public string PublisherId { get; set; } = null!;

    public int BookPrice { get; set; }

    public string? BookDetail { get; set; }

    public string? BookImage1 { get; set; }

    public string? BookImage2 { get; set; }

    public string? BookImage3 { get; set; }

    public virtual TableAuthor Author { get; set; } = null!;

    public virtual TableCategory Category { get; set; } = null!;

    public virtual TablePublisher Publisher { get; set; } = null!;

    public virtual TableStoreOwner StoreOwner { get; set; } = null!;

    public virtual ICollection<TableOrderDetail> TableOrderDetails { get; set; } = new List<TableOrderDetail>();
}
