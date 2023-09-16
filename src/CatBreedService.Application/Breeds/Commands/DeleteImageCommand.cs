using CatBreedService.Infrastructure;
using MediatR;

namespace CatBreedService.Application.Breeds.Commands
{
    public class DeleteImageCommand : IRequest<bool>
    {
        public string BreedId { get; }
        public Guid ImageId { get; }

        public DeleteImageCommand(string breedId, Guid imageId)
        {
            BreedId = breedId;
            ImageId = imageId;
        }

        public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, bool>
        {
            private readonly CatBreedDbContext _dbContext;

            public DeleteImageCommandHandler(CatBreedDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<bool> Handle(DeleteImageCommand command, CancellationToken cancellationToken)
            {
                var image = _dbContext.Images.FirstOrDefault(i => i.BreedId == command.BreedId && i.Id == command.ImageId);
                if (image == null)
                {
                    return false;
                }
                _dbContext.Images.Remove(image);
                var isSuccess = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
                if (isSuccess)
                {
                    return true;
                }
                throw new Exception("Something went wrong!");
            }
        }
    }
}
