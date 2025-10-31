using FastEndpoints;

namespace RiverBooks.Books.BookEndpoints;

internal class Delete(IBookService bookService) : Endpoint<DeleteBookRequest>
{
    public override async Task HandleAsync(DeleteBookRequest req, CancellationToken ct)
    {
        // TODO: Handle Not found
        await bookService.DeleteBookAsync(req.Id);
        await Send.NotFoundAsync(ct);
    }

    public override void Configure()
    {
        Delete("/books/{id}");
        AllowAnonymous();
    }
}
