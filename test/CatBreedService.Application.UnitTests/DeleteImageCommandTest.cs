using CatBreedService.Application.Breeds.Commands;
using FluentAssertions;
using AutoFixture;
using Xunit;
using static CatBreedService.Application.Breeds.Commands.DeleteImageCommand;


namespace CatBreedService.Application.UnitTests
{
    public class DeleteImageCommandTest : BaseTest
    {
        [Fact]
        public async Task DeleteImage_WhenNotFoundImage_ThenReturnFalse()
        {
            var command = _fixture.Create<DeleteImageCommand>();
            var handler = new DeleteImageCommandHandler(_dbContext);

            var result =  await handler.Handle(command, CancellationToken.None);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task DeleteImage_WhenFoundImage_ThenDelete()
        {
            var command = new DeleteImageCommand(_imageFixture.BreedId, _imageFixture.Id);
            var handler = new DeleteImageCommandHandler(_dbContext);

            var result =  await handler.Handle(command, CancellationToken.None);

            result.Should().BeTrue();
        }
    }
}

