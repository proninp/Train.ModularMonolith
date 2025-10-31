using FastEndpoints;

namespace RiverBooks.Books.BookEndpoints;

internal class Create(IBookService bookService) :
    Endpoint<CreateBookRequest, BookDto>
{
    public override async Task HandleAsync(CreateBookRequest req, CancellationToken ct)
    {
        var newBook = new BookDto(req.Id ?? Guid.NewGuid(), req.Title, req.Author, req.Price);
        await bookService.CreateBookAsync(newBook);
        await Send.CreatedAtAsync<GetById>(new {newBook.Id }, newBook, cancellation: ct);
    }

    public override void Configure()
    {
        Post("/books/create");
        AllowAnonymous();
    }
}
