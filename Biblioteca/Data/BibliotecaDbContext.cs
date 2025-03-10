using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Data
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options ) : base(options)
        {
        }

        public DbSet<Book> books { get; set; }

        protected BibliotecaDbContext()
        {
        }
    }
}
