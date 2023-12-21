using System.ComponentModel.DataAnnotations.Schema;


namespace FPTWeb.Data
{
	[Table("Order")]
	public partial class Order
	{
		public int OrderId { get; set; }

		public string UserId { get; set; } = null!;

		public DateTime? OrderDate { get; set; }

		public decimal? TotalAmount { get; set; }
		[ForeignKey("UserId")]
		public virtual FptBookUser? FptBookUser { get; set; }

		public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
	}
}
