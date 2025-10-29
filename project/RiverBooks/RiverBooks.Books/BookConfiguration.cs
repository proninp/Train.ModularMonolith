using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    private static readonly Guid _book1Guid = new Guid("34125d61-9ae7-4dda-994b-d9623b3fbcff");
    private static readonly Guid _book2Guid = new Guid("66b37ca5-6445-4da8-bac2-4896b9273a8c");
    private static readonly Guid _book3Guid = new Guid("2dd04ba1-81b5-4a2b-b5d7-d9a8520628e1");
    
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Title)
            .HasMaxLength(DataSchemaConstants.DefaultNameLength)
            .IsRequired();
        
        builder.Property(b => b.Author)
            .HasMaxLength(DataSchemaConstants.DefaultNameLength)
            .IsRequired();

        builder.HasData(GetSampleBookData());
    }

    private IEnumerable<Book> GetSampleBookData()
    {
        yield return new Book(_book1Guid, "Clean Architecture", "Robert C. Martin", 10.99m);
        yield return new Book(_book2Guid, "Domain-Driven Design", "Eric Evans", 11.99m);
        yield return new Book(_book3Guid, "Implementing Domain-Driven Design", "Vaughn Vernon", 12.99m);
    }
}
