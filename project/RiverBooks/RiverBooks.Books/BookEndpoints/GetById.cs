using FastEndpoints;

namespace RiverBooks.Books.BookEndpoints;

internal class GetById(IBookService bookService) :
    Endpoint<GetBookByIdRequest, BookDto>
{
    public override async Task HandleAsync(GetBookByIdRequest req, CancellationToken ct)
    {
        var book = await bookService.GetBookByIdAsync(req.Id);
        if (book is null)
        {
            await Send.NotFoundAsync(ct);
            return;
        }
        await Send.OkAsync(book, ct);
    }

    public override void Configure()
    {
        Get("/books/{id}");
        AllowAnonymous();
    }
}
