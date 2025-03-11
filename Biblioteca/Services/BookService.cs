using Biblioteca.Data;
using Biblioteca.ViewModels;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class BookService
    {
        private readonly BibliotecaDbContext _context;

        public BookService(BibliotecaDbContext context)
        {
            //mettiamo il DB nel servizio
            _context = context;
        }

        private async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<BooksListViewModel> GetAllBooksAsync()
        {
            try
            {
                var booksList = new BooksListViewModel();

                booksList.Books = await _context.books.ToListAsync();

                return booksList;
            }
            catch
            {
                return new BooksListViewModel() { Books = new List<Book>()};
            }
        }

        public async Task<bool> AddBookAsync(AddBookViewModel addBookViewModel)
        {
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = addBookViewModel.Title,
                Author = addBookViewModel.Author,
                genre = addBookViewModel.genre,
                availability = addBookViewModel.availability,
                CoverUrl = addBookViewModel.CoverUrl
            };

            _context.books.Add(book);
            return await SaveAsync();
        }
    }
}
