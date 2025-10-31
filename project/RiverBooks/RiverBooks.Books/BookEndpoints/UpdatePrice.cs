using FastEndpoints;

namespace RiverBooks.Books.BookEndpoints;

internal class UpdatePrice(IBookService bookService) : Endpoint<UpdateBookPriceRequest, BookDto>
{
    public override async Task HandleAsync(UpdateBookPriceRequest req, CancellationToken ct)
    {
        // TODO: Handle Not found
        await bookService.UpdateBookPriceAsync(req.Id, req.NewPrice);
        var updatedBook = await bookService.GetBookByIdAsync(req.Id);
        await Send.OkAsync(updatedBook, ct);
    }

    public override void Configure()
    {
        Post("/books/{Id}/priceHistory");
        AllowAnonymous();
    }
}
