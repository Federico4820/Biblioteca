using System.Threading.Tasks;
using Biblioteca.Services;
using Biblioteca.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            //metto il servizio nel controller
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var bookList = await _bookService.GetAllBooksAsync();
            return View(bookList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddBookViewModel addBooksViewModel)
        {
            var result = await _bookService.AddBookAsync(addBooksViewModel);
            if (!result)
            {
                TempData["Error"] = "Error during saving book in database";
            }
            return RedirectToAction("Index");
        }

        [Route("product/Info/{Id:guid}")]
        public async Task<IActionResult> Info(Guid Id)
        {
            var Info = await _bookService.GetBookByIdAsync(Id);

            if (Info.Title == null)
            {
                TempData["Error"] = "Error finding info on database";
                return RedirectToAction("Index"); 
            }

            return View(Info);
        }
    }
}
