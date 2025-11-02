using FastEndpoints;
using FastEndpoints.Testing;
using RiverBooks.Books.BookEndpoints;
using RiverBooks.Books.Tests.Endpoints;

namespace RiverBooks.Books.Tests;

public class BookGetById(Fixture fixture) : TestBase<Fixture>
{
    [Theory]
    [InlineData("66B37CA5-6445-4DA8-BAC2-4896B9273A8C", "Domain-Driven Design")]
    [InlineData("34125D61-9AE7-4DDA-994B-D9623B3FBCFF", "Clean Architecture")]
    [InlineData("2DD04BA1-81B5-4A2B-B5D7-D9A8520628E1", "Implementing Domain-Driven Design")]
    public async Task ReturnsBooksForKnownIdsAsync(string validId, string expectedTitle)
    {
        var id  = Guid.Parse(validId);
        var request = new GetBookByIdRequest { Id = id };
        var testResult = await fixture.Client.GETAsync<GetById, GetBookByIdRequest, BookDto>(request);
        
        testResult.Response.EnsureSuccessStatusCode();
        testResult.Result.Title.ShouldBe(expectedTitle);
    }
}
