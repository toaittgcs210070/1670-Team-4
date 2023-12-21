using System.ComponentModel.DataAnnotations.Schema;

namespace FPTWeb.Data
{
    [Table("Publisher")]
    public partial class Publisher
    {
        public int PublisherId { get; set; }

        public string PublisherName { get; set; } = null!;

        public string? PublisherAddress { get; set; }

        public string? PublisherLogo { get; set; }

        public string? PublisherDetails { get; set; }

        public int? FoundingYear { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
