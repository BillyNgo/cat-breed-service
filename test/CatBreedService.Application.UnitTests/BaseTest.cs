using AutoFixture;
using AutoMapper;
using CatBreedService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CatBreedService.Application.Configurations.Mapping;
using CatBreedService.Domain.AggregatesModel.BreedAggregate;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace CatBreedService.Application.UnitTests
{
    public class BaseTest : IDisposable
    {
        public readonly CatBreedDbContext _dbContext;
        public readonly IMapper _mapper;
        public readonly IFixture _fixture;
        public readonly Image _imageFixture;
        public readonly Breed _breedFixture;
        public BaseTest()
        {
            var dbOptions = new DbContextOptionsBuilder<CatBreedDbContext>().UseInMemoryDatabase("CatBreedDb").Options;
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new ApplicationAutoMapperProfile()));

            _dbContext = new CatBreedDbContext(dbOptions);
            _mapper = new Mapper(configuration);
            _fixture = new Fixture();

            _breedFixture = _fixture.Build<Breed>()
                .With(x => x.Id, "abys")
                .Create();
            
            _imageFixture = _fixture.Build<Image>()
                .With(x => x.BreedId, "abys")
                .Create();

            _dbContext.Breeds.Add(_breedFixture);
            _dbContext.Images.Add(_imageFixture);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            // Do "global" teardown here; Called after every test method.
            try
            {
                _dbContext.Breeds.Remove(_breedFixture);
                _dbContext.Images.Remove(_imageFixture);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }
}
