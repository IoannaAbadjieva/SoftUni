namespace Library.Contracts
{
    using Models;

    public interface IBookService
    {
        Task<IEnumerable<AllBooksViewModel>> GetAllBooksAsync();

        Task<IEnumerable<AllBooksViewModel>> GetMyBooksAsync(string UserId);

        Task<BookViewModel?> GetBookByIdAsync(int id);

        Task AddBookToCollectionAsync(string userId, BookViewModel book);

        Task RemoveBookFromCollectionAsync(string userId, BookViewModel book);

        Task<AddBookViewModel> GetNewAddBookViewModelAsync();

        Task AddBookAsync(AddBookViewModel model);
    }
}
