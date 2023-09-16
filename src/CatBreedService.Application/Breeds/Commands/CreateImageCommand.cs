using AutoMapper;
using CatBreedService.Application.Breeds.Dtos;
using CatBreedService.Domain.AggregatesModel.BreedAggregate;
using CatBreedService.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CatBreedService.Application.Breeds.Commands
{
    public class CreateImageCommand : IRequest<ImageDto>
    {
        public string BreedId { get; private set; }
        public string Url { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        
        public CreateImageCommand(string breedId, string url, int width, int height)
        {
            BreedId = breedId;
            Url = url;
            Width = width;
            Height = height;
        }
        
        public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, ImageDto>
        {
            private readonly CatBreedDbContext _dbContext;
            private readonly IMapper _mapper;

            public CreateImageCommandHandler(CatBreedDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<ImageDto> Handle(CreateImageCommand command, CancellationToken cancellationToken)
            {
                var image = new Image
                {
                    BreedId = command.BreedId,
                    Url = command.Url,
                    Width = command.Width,
                    Height = command.Height
                };
    
                _dbContext.Images.Add(image);
                var isSuccess = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
                if (isSuccess)
                {
                    return _mapper.Map<Image, ImageDto>(image);
                }
                throw new Exception("Something went wrong!");
            }
        }
    }
}
