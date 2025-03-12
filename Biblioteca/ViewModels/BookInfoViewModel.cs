using Biblioteca.Models;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.ViewModels
{
    public class BookInfoViewModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? genre { get; set; }

        public AvailabilityStatus availability { get; set; }

        public string? CoverUrl { get; set; }
    }
}
