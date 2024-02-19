namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Contracts;
    using Models;

    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService _bookService)
        {
            bookService = _bookService;

        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AllBooksViewModel> model = await bookService.GetAllBooksAsync();
            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            IEnumerable<AllBooksViewModel> model = await bookService.GetMyBooksAsync(GetUserId() ?? string.Empty);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            BookViewModel? book = await bookService.GetBookByIdAsync(id);

            if (book != null)
            {
                string userId = GetUserId();
                await bookService.AddBookToCollectionAsync(userId, book);
            }

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            BookViewModel? book = await bookService.GetBookByIdAsync(id);

            if (book != null)
            {
                string userId = GetUserId();
                await bookService.RemoveBookFromCollectionAsync(userId, book);
            }

            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await bookService.GetNewAddBookViewModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult>Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.AddBookAsync(model);

            return RedirectToAction(nameof(All));
        }
    }
}
