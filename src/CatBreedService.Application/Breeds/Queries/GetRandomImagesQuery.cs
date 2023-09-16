using AutoMapper;
using CatBreedService.Application.Breeds.Dtos;
using CatBreedService.Domain.AggregatesModel.BreedAggregate;
using CatBreedService.Infrastructure;
using MediatR;

namespace CatBreedService.Application.Breeds.Queries
{
    public class GetRandomImagesQuery : IRequest<IEnumerable<ImageDto>>
    {
        public class GetRandomImagesQueryHandler : IRequestHandler<GetRandomImagesQuery, IEnumerable<ImageDto>>
        {
            private readonly CatBreedDbContext _dbContext;
            private readonly IMapper _mapper;
            private const int Limit = 10;


            public GetRandomImagesQueryHandler(CatBreedDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public Task<IEnumerable<ImageDto>> Handle(GetRandomImagesQuery query, CancellationToken cancellationToken)
            {
                // Get a random indexList from 0 -> numberOfImages
                var imageCount = _dbContext.Images.Count();
                var rand = new Random();
                var indexList = Enumerable.Range(0, Limit > imageCount ? imageCount : Limit)
                    .Select(i => new Tuple<int, int>(rand.Next(imageCount - 1), i))
                    .OrderBy(i => i.Item2)
                    .Select(i => i.Item1).ToList();

                // Select images with index in random indexList
                var randomImageList = new List<Image>();
                for (var i = 0; i < indexList.Count(); i++)
                {
                    var image = _dbContext.Images.Skip(indexList.ElementAt(i)).Take(1).ToList().FirstOrDefault();
                    if (image != null) randomImageList.Add(image);
                }

                var imageDtoList = _mapper.Map<List<Image>, List<ImageDto>>(randomImageList);
                return Task.FromResult<IEnumerable<ImageDto>>(imageDtoList);
            }
        }
    }

}
