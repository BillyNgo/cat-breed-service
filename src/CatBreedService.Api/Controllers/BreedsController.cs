using CatBreedService.Application.Breeds.Commands;
using CatBreedService.Application.Breeds.Dtos;
using CatBreedService.Application.Breeds.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatBreedService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreedsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BreedsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get a specific breed.
        /// </summary>
        /// <param name="breedId">Specific breedId.</param>
        /// <returns>Return a specific breed.</returns>
        [HttpGet, Route("{breedId}")]
        [ProducesResponseType(typeof(BreedDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] string breedId)
        {
            var breedDto = await _mediator.Send(new FindBreedByIdQuery(breedId));
            return Ok(breedDto);
        }

        /// <summary>
        /// Get all breeds.
        /// </summary>
        /// <returns>A list of all breeds.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BreedDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var breedDtoList = await _mediator.Send(new GetAllBreedsQuery());
            return Ok(breedDtoList);
        }

        /// <summary>
        /// Get a list of images from a specific breed.
        /// </summary>
        /// <param name="breedId">Specific breedId.</param>
        /// <returns>Return a random list of images.</returns>
        [HttpGet, Route("{breedId}/Images")]
        [ProducesResponseType(typeof(IEnumerable<ImageDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetImages(string breedId)
        {
            var imageDtoList = await _mediator.Send(new FindImagesByBreedIdQuery(breedId));
            return Ok(imageDtoList);
        }

        /// <summary>
        /// Get a specific image.
        /// </summary>
        /// <param name="imageId">Specific imageId (Guid).</param>
        /// <returns>Return a specific image.</returns>
        [HttpGet, Route("Images/{imageId:guid}")]
        [ProducesResponseType(typeof(IEnumerable<ImageDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetImage(Guid imageId)
        {
            var imageDto = await _mediator.Send(new FindImageByIdQuery(imageId));
            return Ok(imageDto);
        }

        /// <summary>
        /// Get a random list of images.
        /// </summary>
        /// <returns>Return a random list of images.</returns>
        [HttpGet, Route("Images")]
        [ProducesResponseType(typeof(IEnumerable<ImageDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRandomImages()
        {
            var imageDtoList = await _mediator.Send(new GetRandomImagesQuery());
            return Ok(imageDtoList);
        }

        /// <summary>
        /// Attach an image to a specific breed.
        /// </summary>
        /// <param name="createImageCommand">Image info.</param>
        /// <returns>New image with Guid</returns>
        [HttpPost, Route("Images")]
        [ProducesResponseType(typeof(IEnumerable<ImageDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateImage(CreateImageCommand createImageCommand)
        {
            var imageDto = await _mediator.Send(createImageCommand);
            return Ok(imageDto);
        }

        /// <summary>
        /// Delete an image from a specific breed.
        /// </summary>
        /// <param name="breedId">Specific breedId.</param>
        /// <param name="imageId">Specific imageId.</param>
        /// <returns>Operation status</returns>
        [HttpDelete, Route("{breedId}/Images/{imageId}")]
        [ProducesResponseType(typeof(IEnumerable<BreedDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteImage(string breedId, Guid imageId)
        {
            var isSuccess = await _mediator.Send(new DeleteImageCommand(breedId, imageId));
            if (!isSuccess)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}