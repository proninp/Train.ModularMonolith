namespace RiverBooks.Books;

internal interface IBookBooksRepository : IReadOnlyBooksRepository
{
    Task AddAsync(Book book);

    Task DeleteAsync(Book book);
    
    Task SaveChangesAsync();
}
