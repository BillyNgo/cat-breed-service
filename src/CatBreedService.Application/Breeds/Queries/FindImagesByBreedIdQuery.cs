using AutoMapper;
using CatBreedService.Application.Breeds.Dtos;
using CatBreedService.Domain.AggregatesModel.BreedAggregate;
using CatBreedService.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatBreedService.Application.Breeds.Queries
{
    public class FindImagesByBreedIdQuery : IRequest<IEnumerable<ImageDto>>
    {
        public string BreedId { get; }

        public FindImagesByBreedIdQuery(string breedId)
        {
            BreedId = breedId;
        }

        public class FindImagesByBreedIdQueryHandler : IRequestHandler<FindImagesByBreedIdQuery, IEnumerable<ImageDto>>
        {
            private readonly CatBreedDbContext _dbContext;
            private readonly IMapper _mapper;

            public FindImagesByBreedIdQueryHandler(CatBreedDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ImageDto>> Handle(FindImagesByBreedIdQuery query, CancellationToken cancellationToken)
            {
                var imageList = await _dbContext.Images.Where(i => i.BreedId.Equals(query.BreedId)).ToListAsync(cancellationToken);
                var imagesDtoList = _mapper.Map<IEnumerable<Image>, IEnumerable<ImageDto>>(imageList);
                return imagesDtoList;
            }
        }
    }
}
