using CatBreedService.Domain.AggregatesModel.BreedAggregate;
using CatBreedService.Infrastructure;
using Newtonsoft.Json;

namespace CatBreedService.Api.Extensions
{
    internal static class DbInitializerExtension
    {
        public static IApplicationBuilder UseDataSeeding(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<CatBreedDbContext>();
                DbInitializer.Seed(context);
            }
            catch (Exception ex)
            {
                //ignore
            }

            return app;
        }

        private static class DbInitializer
        {
            public static void Seed(CatBreedDbContext dbContext)
            {
                dbContext.Database.EnsureCreated();
                var breedResponse = ApiClient("https://api.thecatapi.com/v1/breeds");
                var breeds = JsonConvert.DeserializeObject<List<Breed>>(breedResponse);
                if (breeds != null)
                {
                    foreach (var breed in breeds)
                    {
                        //Import data from https://api.thecatapi.com (Will take some time and also need to change imageId from Guid to string)

                        //var imageResponse = ApiClient($"https://api.thecatapi.com/v1/images/search?limit=3&breed_ids={breed.Id}");
                        //if (string.IsNullOrEmpty(imageResponse)) return;
                        //var imageList = JsonConvert.DeserializeObject<List<Image>>(imageResponse);
                        //if (imageList is not { Count: > 0 }) continue;
                        //imageList.ForEach(a => a.BreedId = breed.Id);
                        //dbContext.Images.AddRange(imageList);

                        //Import fake data.
                        var imageList = new List<Image>
                        {
                            new Image
                            {
                                BreedId = breed.Id,
                                Url = $"https://cdn2.thecatapi.com/images/{RandomName()}.jpg",
                                Width = 1024,
                                Height = 1024,
                            },
                            new Image
                            {
                                BreedId = breed.Id,
                                Url = $"https://cdn2.thecatapi.com/images/{RandomName()}.jpg",
                                Width = 1024,
                                Height = 1024,
                            }
                        };
                        dbContext.Images.AddRange(imageList);
                    }

                    dbContext.Breeds.AddRange(breeds);
                }

                dbContext.SaveChanges();
            }

            private static string ApiClient(string url)
            {
                using var httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = httpClient.Send(request);
                using var r = new StreamReader(response.Content.ReadAsStream());
                return r.ReadToEnd();
            }

            private static string RandomName()
            {
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[8];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                return finalString;
            }
        }

        
    }
}
