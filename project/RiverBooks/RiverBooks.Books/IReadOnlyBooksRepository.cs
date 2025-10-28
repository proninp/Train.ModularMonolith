namespace RiverBooks.Books;

internal interface IReadOnlyBooksRepository
{
    Task<Book?> GetByIdAsync(Guid id);
    
    Task<List<Book>> GetAllAsync();
}
