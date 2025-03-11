using Biblioteca.Models;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.ViewModels
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(50)]
        public required string Title { get; set; }

        [Required]
        [StringLength(20)]
        public required string Author { get; set; }

        [Required]
        [StringLength(20)]
        public required string genre { get; set; }

        [Required]
        public required AvailabilityStatus availability { get; set; }

        [Required]
        [StringLength(200)]
        [Url]
        public required string CoverUrl { get; set; }
    }
}
