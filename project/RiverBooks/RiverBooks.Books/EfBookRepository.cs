using Microsoft.EntityFrameworkCore;

namespace RiverBooks.Books;

internal class EfBookRepository(BookDbContext context) : IBookRepository
{
    public async Task<Book?> GetByIdAsync(Guid id)
    {
        return await context.Books.FindAsync(id);
    }

    public async Task<List<Book>> GetAllAsync()
    {
        return await context.Books.ToListAsync();
    }

    public async Task AddAsync(Book book)
    {
        await context.Books.AddAsync(book);
    }

    public Task DeleteAsync(Book book)
    {
        context.Books.Remove(book);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
