﻿namespace RiverBooks.Books;

internal interface IBookRepository : IReadOnlyBooksRepository
{
    Task AddAsync(Book book);

    Task DeleteAsync(Book book);
    
    Task SaveChangesAsync();
}
