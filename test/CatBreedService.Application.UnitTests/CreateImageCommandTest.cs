using AutoMapper;
using CatBreedService.Application.Breeds.Commands;
using CatBreedService.Application.Configurations.Mapping;
using CatBreedService.Domain.AggregatesModel.BreedAggregate;
using CatBreedService.Infrastructure;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using AutoFixture;
using CatBreedService.Application.Breeds.Dtos;
using Microsoft.EntityFrameworkCore;
using Xunit;
using static CatBreedService.Application.Breeds.Commands.CreateImageCommand;

namespace CatBreedService.Application.UnitTests
{
    public class CreateImageCommandTest : BaseTest
    {
        [Fact]
        public async Task CreateImage_WhenSaveSuccess_ThenCreate()
        {
            var command = _fixture.Create<CreateImageCommand>();
            var image = new Image
            {
                BreedId = command.BreedId,
                Url = command.Url,
                Width = command.Width,
                Height = command.Height
            };

            var handler = new CreateImageCommandHandler(_dbContext, _mapper);
            var result =  await handler.Handle(command, CancellationToken.None);
            var expected = _mapper.Map<Image, ImageDto>(image);

            result.Should().NotBeNull();
            result.Id.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(expected, options => options.Excluding(r => r.Id));
        }

        [Fact]
        public async Task CreateImage_WhenSaveFail_ThenThrowException()
        {
            var command = _fixture.Create<CreateImageCommand>();

            var image = new Image
            {
                BreedId = command.BreedId,
                Url = command.Url,
                Width = command.Width,
                Height = command.Height
            };

            var dbContextMock = new Mock<CatBreedDbContext>();
            dbContextMock.Setup(p => p.Images.Add(image)).Returns(It.IsAny<EntityEntry<Image>>());
            dbContextMock.Setup(p => p.SaveChangesAsync(CancellationToken.None)).Returns(Task.FromResult(0));

            var handler = new CreateImageCommandHandler(dbContextMock.Object, _mapper);
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            await act.Should().ThrowAsync<Exception>();
            dbContextMock.Verify(m => m.Images.Add(image), Times.Once);
            dbContextMock.Verify(m => m.SaveChangesAsync(CancellationToken.None), Times.Once);
        }
    }
}

