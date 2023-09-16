using FluentAssertions;
using AutoFixture;
using CatBreedService.Application.Breeds.Queries;
using Xunit;
using static CatBreedService.Application.Breeds.Queries.GetRandomImagesQuery;

namespace CatBreedService.Application.UnitTests
{
    public class GetRandomImagesQueryTest : BaseTest
    {
        [Fact]
        public async Task GetRandomImages_WhenNotFound_ThenReturnEmpty()
        {
            var query = _fixture.Create<GetRandomImagesQuery>();
            var handler = new GetRandomImagesQueryHandler(_dbContext, _mapper);

            var result =  await handler.Handle(query, CancellationToken.None);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetRandomImages_WhenFound_ThenReturn()
        {
            var query = new GetRandomImagesQuery();
            var handler = new GetRandomImagesQueryHandler(_dbContext, _mapper);

            var result =  await handler.Handle(query, CancellationToken.None);

            result.Should().NotBeEmpty();
            result.Should().HaveCount(1);
        }
    }
}

