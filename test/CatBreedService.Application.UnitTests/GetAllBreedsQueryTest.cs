using FluentAssertions;
using AutoFixture;
using CatBreedService.Application.Breeds.Queries;
using Xunit;
using static CatBreedService.Application.Breeds.Queries.GetAllBreedsQuery;
using Microsoft.EntityFrameworkCore;


namespace CatBreedService.Application.UnitTests
{
    public class GetAllBreedsQueryTest : BaseTest
    {
        [Fact]
        public async Task GetAllBreeds_WhenNotFound_ThenReturnEmpty()
        {
            _dbContext.Breeds.Remove(_breedFixture);
            await _dbContext.SaveChangesAsync();
            var query = _fixture.Create<GetAllBreedsQuery>();
            var handler = new GetAllBreedsQueryHandler(_dbContext, _mapper);

            var result =  await handler.Handle(query, CancellationToken.None);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllBreeds_WhenFound_ThenReturn()
        {
            var query = new GetAllBreedsQuery();
            var handler = new GetAllBreedsQueryHandler(_dbContext, _mapper);

            var result =  await handler.Handle(query, CancellationToken.None);

            result.Should().NotBeEmpty();
            result.Should().HaveCount(1);
        }
    }
}

