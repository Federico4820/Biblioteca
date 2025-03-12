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

        public async Task<BookInfoViewModel> GetBookByIdAsync(Guid Id)
        {
            var book = await _context.books.FindAsync(Id);

            if (book == null)
            {
                return new BookInfoViewModel();
            }

            var info = new BookInfoViewModel()
            {
                Id = book.Id,
                Title=book.Title,
                Author=book.Author,
                genre=book.genre,
                availability=book.availability,
                CoverUrl=book.CoverUrl
            };
            return info;
        }

        public async Task<bool> DeleteBookByIdAsync(Guid Id)
        {
            var book = await _context.books.FindAsync(Id);
            if (book == null)
            {
                return false;
            }
            _context.books.Remove(book);
            return await SaveAsync();
        }

        public async Task<bool> UpdateBookAsync(BookInfoViewModel bookInfoViewModel)
        {
            var book = await _context.books.FindAsync(bookInfoViewModel.Id);
            if (book == null)
            {
                return false;
            }

            book.Id = bookInfoViewModel.Id;
            book.Title = bookInfoViewModel.Title;
            book.Author = bookInfoViewModel.Author;
            book.genre = bookInfoViewModel.genre;
            book.availability = bookInfoViewModel.availability;
            book.CoverUrl = bookInfoViewModel.CoverUrl;
            _context.books.Update(book);
            return await SaveAsync();
        }
    }
}
