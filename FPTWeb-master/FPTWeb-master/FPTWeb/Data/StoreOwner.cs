using System.ComponentModel.DataAnnotations.Schema;

namespace FPTWeb.Data
{
    [Table("StoreOwner")]

    public partial class StoreOwner
    {
        public int StoreOwnerId { get; set; }

        public string StoreOwnerName { get; set; } = null!;

        public string StoreOwnerPassword { get; set; } = null!;

        public string StoreOwnerEmail { get; set; } = null!;

        public string? StoreOwnerPhone { get; set; }

        public string? StoreOwnerPhoto { get; set; }

        public string? StoreOwnerAddress { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }

}
