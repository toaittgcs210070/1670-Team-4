using System.ComponentModel.DataAnnotations.Schema;

namespace FPTWeb.Data
{
	[Table("Book")]

	public partial class Book
	{
		public int BookId { get; set; }

		public string? BookImage { get; set; }

		public string Title { get; set; } = null!;

		public string? Description { get; set; }

		public decimal Price { get; set; }

		public int? AuthorId { get; set; }

		public int? CategoryId { get; set; }

		public int? PublisherId { get; set; }

		public int? StoreOwnerId { get; set; }
		[ForeignKey("AuthorId")]
		public virtual Author? Author { get; set; }
		[ForeignKey("CategoryId")]
		public virtual Category? Category { get; set; }

		public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
		[ForeignKey("PublisherId")]
		public virtual Publisher? Publisher { get; set; }
		[ForeignKey("StoreOwnerId")]
		public virtual StoreOwner? StoreOwner { get; set; }
	}
}
