using CatBreedService.Application.Breeds.Commands;
using FluentAssertions;
using AutoFixture;
using CatBreedService.Application.Breeds.Queries;
using Microsoft.Azure.Cosmos.Linq;
using Xunit;
using static CatBreedService.Application.Breeds.Queries.FindBreedByIdQuery;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;


namespace CatBreedService.Application.UnitTests
{
    public class FindBreedByIdQueryTest : BaseTest
    {
        [Fact]
        public async Task FindBreedById_WhenNotFound_ThenReturnNull()
        {
            var query = _fixture.Create<FindBreedByIdQuery>();
            var handler = new FindBreedByIdQueryHandler(_dbContext, _mapper);

            var result =  await handler.Handle(query, CancellationToken.None);

            result.Should().BeNull();
        }

        [Fact]
        public async Task FindBreedById_WhenFound_ThenReturn()
        {
            var query = new FindBreedByIdQuery(_breedFixture.Id);
            var handler = new FindBreedByIdQueryHandler(_dbContext, _mapper);

            var result =  await handler.Handle(query, CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().BeEquivalentTo(query.Id);
        }
    }
}

