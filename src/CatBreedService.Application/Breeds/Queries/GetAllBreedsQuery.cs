using AutoMapper;
using CatBreedService.Application.Breeds.Dtos;
using CatBreedService.Domain.AggregatesModel.BreedAggregate;
using CatBreedService.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatBreedService.Application.Breeds.Queries
{
    public class GetAllBreedsQuery : IRequest<IEnumerable<BreedDto>>
    {
        public class GetAllBreedsQueryHandler : IRequestHandler<GetAllBreedsQuery, IEnumerable<BreedDto>>
        {
            private readonly CatBreedDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllBreedsQueryHandler(CatBreedDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<IEnumerable<BreedDto>> Handle(GetAllBreedsQuery query, CancellationToken cancellationToken)
            {
                var breedList = await _dbContext.Breeds.ToListAsync(cancellationToken: cancellationToken);
                var breedDtoList = _mapper.Map<List<Breed>, List<BreedDto>>(breedList);
                return breedDtoList;
            }
        }
    }

}
