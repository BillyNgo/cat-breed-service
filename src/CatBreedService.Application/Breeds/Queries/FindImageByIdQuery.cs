using AutoMapper;
using CatBreedService.Application.Breeds.Dtos;
using CatBreedService.Domain.AggregatesModel.BreedAggregate;
using CatBreedService.Infrastructure;
using MediatR;

namespace CatBreedService.Application.Breeds.Queries
{
    public class FindImageByIdQuery : IRequest<ImageDto>
    {
        public Guid ImageId { get; }

        public FindImageByIdQuery(Guid imageId)
        {
            ImageId = imageId;
        }

        public class FindImageByIdQueryHandler : IRequestHandler<FindImageByIdQuery, ImageDto?>
        {
            private readonly CatBreedDbContext _dbContext;
            private readonly IMapper _mapper;

            public FindImageByIdQueryHandler(CatBreedDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<ImageDto?> Handle(FindImageByIdQuery query, CancellationToken cancellationToken)
            {
                var image = await _dbContext.Images.FindAsync(query.ImageId);
                if (image == null) return null;
                var imageDto = _mapper.Map<Image, ImageDto>(image);
                return imageDto;
            }
        }
    }
}
