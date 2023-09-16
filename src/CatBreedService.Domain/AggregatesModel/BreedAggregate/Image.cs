using Newtonsoft.Json;

namespace CatBreedService.Domain.AggregatesModel.BreedAggregate
{
    public record Image : IAggregateRoot
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public string BreedId { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
