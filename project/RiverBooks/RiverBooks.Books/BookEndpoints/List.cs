using FastEndpoints;

namespace RiverBooks.Books.BookEndpoints;

internal class List(IBookService bookService) :
    EndpointWithoutRequest<ListBooksResponse>
{
    public override void Configure()
    {
        Get("/books");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var books = await bookService.ListBooksAsync();

        await Send.OkAsync(new ListBooksResponse() { Books = books }, cancellationToken);
    }
}
