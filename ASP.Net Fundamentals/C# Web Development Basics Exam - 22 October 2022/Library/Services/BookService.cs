namespace Library.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Data;
    using Data.Models;
    using Models;

    public class BookService : IBookService
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<IEnumerable<AllBooksViewModel>> GetAllBooksAsync()
        {
            return await dbContext
                .Books
                .Select(book => new AllBooksViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ImageUrl = book.ImageUrl,
                    Rating = book.Rating,
                    Category = book.Category.Name
                })
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<IEnumerable<AllBooksViewModel>> GetMyBooksAsync(string UserId)
        {
            return await dbContext
                .IdentityUserBook
                .Where(ub => ub.CollectorId == UserId)
                .Select(b => new AllBooksViewModel
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                })
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await dbContext
                .Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Url = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId

                })
                .FirstOrDefaultAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            IdentityUserBook? userBook = await dbContext
                 .IdentityUserBook
                 .FirstOrDefaultAsync(ub => ub.BookId == book.Id && ub.CollectorId == userId);

            if (userBook == null)
            {
                await dbContext.IdentityUserBook.AddAsync(new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id,
                });
                await dbContext.SaveChangesAsync();
            }

        }

        public async Task RemoveBookFromCollectionAsync(string userId, BookViewModel book)
        {
            IdentityUserBook? userBook = await dbContext
                .IdentityUserBook
                .FirstOrDefaultAsync(ub => ub.BookId == book.Id && ub.CollectorId == userId);

            if (userBook != null)
            {
                dbContext.IdentityUserBook.Remove(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<AddBookViewModel> GetNewAddBookViewModelAsync()
        {
            CategoryViewModel[] categories = await dbContext
                .Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            AddBookViewModel model = new AddBookViewModel
            {
                Categories = categories
            };

            return model;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.Url,
                Description = model.Description,
                Rating = model.Rating,
                CategoryId = model.CategoryId

            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();
        }
    }
}
