using AutoMapper;
using CatBreedService.Application.Breeds.Dtos;
using CatBreedService.Domain.AggregatesModel.BreedAggregate;

namespace CatBreedService.Application.Configurations.Mapping
{
    public class ApplicationAutoMapperProfile : Profile
    {
        public ApplicationAutoMapperProfile()
        {
            CreateMap<Breed, BreedDto>();
            CreateMap<BreedDto, Breed>();

            CreateMap<Weight, WeightDto>();
            CreateMap<WeightDto, Weight>();
            
            CreateMap<Image, ImageDto>();
            CreateMap<ImageDto, Image>();
        }
    }
}
