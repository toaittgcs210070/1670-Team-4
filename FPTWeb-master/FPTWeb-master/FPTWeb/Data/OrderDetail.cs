using System.ComponentModel.DataAnnotations.Schema;

namespace FPTWeb.Data
{
	[Table("OrderDetail")]

	public partial class OrderDetail
	{
		public int OrderDetailId { get; set; }
		public int? OrderId { get; set; }
		public int? BookId { get; set; }

		public int Quantity { get; set; }

		[ForeignKey("OrderId")]
		public virtual Order? Order { get; set; }
		[ForeignKey("BookId")]
		public virtual Book? Book { get; set; }

	}
}