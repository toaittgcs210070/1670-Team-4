using System.ComponentModel.DataAnnotations.Schema;

namespace FPTWeb.Data
{
    [Table("Category")]
    public partial class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? CatDetails { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
