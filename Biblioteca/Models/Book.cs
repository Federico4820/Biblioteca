using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Biblioteca.Models
{
    public enum AvailabilityStatus
    {
        InStock = 0,
        OutOfStock = 1
    }
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Title { get; set; }

        [Required]
        [StringLength(50)]
        public required string Author { get; set; }

        [Required]
        [StringLength(100)]
        public required string genre { get; set; }

        [Required]
        public required AvailabilityStatus availability { get; set; }

        [Required]
        [StringLength(200)]
        [Url]
        public required string CoverUrl { get; set; }
    }
}
