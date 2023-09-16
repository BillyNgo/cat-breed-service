using CatBreedService.Application.Breeds.Commands;
using FluentAssertions;
using AutoFixture;
using CatBreedService.Application.Breeds.Queries;
using Microsoft.Azure.Cosmos.Linq;
using Xunit;
using static CatBreedService.Application.Breeds.Queries.FindImageByIdQuery;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;


namespace CatBreedService.Application.UnitTests
{
    public class FindImageByIdQueryTest : BaseTest
    {
        [Fact]
        public async Task FindImageById_WhenNotFound_ThenReturnNull()
        {
            var query = _fixture.Create<FindImageByIdQuery>();
            var handler = new FindImageByIdQueryHandler(_dbContext, _mapper);

            var result =  await handler.Handle(query, CancellationToken.None);

            result.Should().BeNull();
        }

        [Fact]
        public async Task FindImageById_WhenFound_ThenReturn()
        {
            var query = new FindImageByIdQuery(_imageFixture.Id);
            var handler = new FindImageByIdQueryHandler(_dbContext, _mapper);

            var result =  await handler.Handle(query, CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().BeEquivalentTo(query.ImageId.ToString());
        }
    }
}

