namespace RiverBooks.Books;

internal class BookService : IBookService
{
    private readonly IBookBooksRepository _bookBooksRepository;

    public BookService(IBookBooksRepository bookBooksRepository)
    {
        _bookBooksRepository = bookBooksRepository;
    }

    public async Task<List<BookDto>> ListBooksAsync()
    {
        var books = (await _bookBooksRepository.GetAllAsync())
            .Select(b => new BookDto(b.Id, b.Title, b.Author, b.Price))
            .ToList();
        return books;
    }

    public async Task<BookDto> GetBookByIdAsync(Guid id)
    {
        var book = await _bookBooksRepository.GetByIdAsync(id);
        
        // TODO: handle not found case
        
        return new BookDto(book!.Id, book.Title, book.Author, book.Price);
    }

    public async Task CreateBookAsync(BookDto newBook)
    {
        var book = new Book(newBook.Id, newBook.Title, newBook.Author, newBook.Price);
        await _bookBooksRepository.AddAsync(book);
        await _bookBooksRepository.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(Guid id)
    {
        var bookToDelete = await _bookBooksRepository.GetByIdAsync(id);
        if (bookToDelete is not null)
        {
            await _bookBooksRepository.DeleteAsync(bookToDelete);
            await _bookBooksRepository.SaveChangesAsync();
        }
    }

    public async Task UpdateBookPriceAsync(Guid bookId, decimal newPrice)
    {
        // validate the price
        var book = await _bookBooksRepository.GetByIdAsync(bookId);
        
        // TODO: handle not found case
        book!.UpdatePrice(newPrice);
        await _bookBooksRepository.SaveChangesAsync();
    }
}
