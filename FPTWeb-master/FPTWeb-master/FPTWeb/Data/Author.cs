using System.ComponentModel.DataAnnotations.Schema;

namespace FPTWeb.Data
{
	[Table("Author")]
	public partial class Author
	{
		public int AuthorId { get; set; }

		public string AuthorName { get; set; } = null!;

		public string? AuthorEmail { get; set; }

		public string? AuthorPhoto { get; set; }

		public DateTime? Birthdate { get; set; }

		public virtual ICollection<Book> Books { get; set; } = new List<Book>();
	}
}
