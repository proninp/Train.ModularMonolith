using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books;

internal interface IBookService
{
    IEnumerable<BookDto> ListBooks();
}

public record BookDto(Guid Id, string Title, string Author);

internal class BookService : IBookService
{
    public IEnumerable<BookDto> ListBooks()
    {
        return
        [
            new BookDto(Guid.NewGuid(), "Clean Architecture", "Robert C. Martin"),
            new BookDto(Guid.NewGuid(), "Domain-Driven Design", "Eric Evans"),
            new BookDto(Guid.NewGuid(), "Implementing Domain-Driven Design", "Vaughn Vernon")
        ];
    }
}

public static class BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        app.MapGet("/books", (IBookService bookService) =>
        {
            return bookService.ListBooks();
        });
    }
}

public static class BookServiceExtensions
{
    public static IServiceCollection AddBookServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        return services;
    }
}