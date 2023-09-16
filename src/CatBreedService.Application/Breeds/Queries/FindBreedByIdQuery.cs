using AutoMapper;
using CatBreedService.Application.Breeds.Dtos;
using CatBreedService.Domain.AggregatesModel.BreedAggregate;
using CatBreedService.Infrastructure;
using MediatR;

namespace CatBreedService.Application.Breeds.Queries
{
    public class FindBreedByIdQuery : IRequest<BreedDto?>
    {
        public string Id { get; }

        public FindBreedByIdQuery(string id)
        {
            Id = id;
        }

        public class FindBreedByIdQueryHandler : IRequestHandler<FindBreedByIdQuery, BreedDto?>
        {
            private readonly CatBreedDbContext _dbContext;
            private readonly IMapper _mapper;

            public FindBreedByIdQueryHandler(CatBreedDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<BreedDto?> Handle(FindBreedByIdQuery query, CancellationToken cancellationToken)
            {
                var breed = await _dbContext.Breeds.FindAsync(query.Id, cancellationToken);
                if (breed == null) return null;
                var breedDto = _mapper.Map<Breed, BreedDto>(breed);
                return breedDto;
            }
        }
    }
}
