using CatBreedService.Application.Breeds.Commands;
using FluentAssertions;
using AutoFixture;
using CatBreedService.Application.Breeds.Queries;
using Microsoft.Azure.Cosmos.Linq;
using Xunit;
using static CatBreedService.Application.Breeds.Queries.FindImagesByBreedIdQuery;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;


namespace CatBreedService.Application.UnitTests
{
    public class FindImagesByBreedIdQueryTest : BaseTest
    {
        [Fact]
        public async Task FindImagesByBreedId_WhenNotFound_ThenReturnNull()
        {
            var query = _fixture.Create<FindImagesByBreedIdQuery>();
            var handler = new FindImagesByBreedIdQueryHandler(_dbContext, _mapper);

            var result =  await handler.Handle(query, CancellationToken.None);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task FindImagesByBreedId_WhenFound_ThenReturn()
        {
            var query = new FindImagesByBreedIdQuery(_breedFixture.Id);
            var handler = new FindImagesByBreedIdQueryHandler(_dbContext, _mapper);

            var result =  await handler.Handle(query, CancellationToken.None);

            result.Should().NotBeEmpty();
            result.Should().HaveCount(1);
        }
    }
}

