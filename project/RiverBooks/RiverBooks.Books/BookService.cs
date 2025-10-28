namespace RiverBooks.Books;

internal class BookService : IBookService
{
    public List<BookDto> ListBooks()
    {
        return
        [
            new BookDto(Guid.NewGuid(), "Clean Architecture", "Robert C. Martin"),
            new BookDto(Guid.NewGuid(), "Domain-Driven Design", "Eric Evans"),
            new BookDto(Guid.NewGuid(), "Implementing Domain-Driven Design", "Vaughn Vernon")
        ];
    }
}
