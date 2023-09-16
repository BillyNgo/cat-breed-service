namespace CatBreedService.Domain.AggregatesModel.BreedAggregate
{
    public record Weight
    {
        public string Imperial { get; set; }
        public string Metric { get; set; }
    }
}
