using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment2Client2.Data
{
    public class CloudAdultService : IAdultService
    {

        private string uri = "https://localhost:5003";

        private readonly HttpClient client;

        private IList<Adult> adults;

        public CloudAdultService()
        {

            client = new HttpClient();
        }

        public async Task<Adult> GetAsync(int id)
        {
            var adultsAsync = await GetAdultsAsync();
            var adultById = adultsAsync.First(a => a.Id == id);
            return adultById;
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/adults");
            string message = await stringAsync;
            Console.WriteLine(message);
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri + "/adults", content);
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            await client.DeleteAsync($"{uri}/adults/{adultId}");
        }

        public async Task UpdateAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PatchAsync($"{uri}/adults/{adult.Id}", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
            else
            {
                Adult toUpdate = adults.FirstOrDefault(t => t.Id == adult.Id);
                if (toUpdate == null) throw new Exception($"Did not find adult with id: {adult.Id}");

                toUpdate.FirstName = adult.FirstName;
                toUpdate.LastName = adult.LastName;
                toUpdate.JobTitle = adult.JobTitle;
                toUpdate.JobTitle = adult.JobTitle;
                toUpdate.HairColor = adult.HairColor;
                toUpdate.EyeColor = adult.EyeColor;
                toUpdate.Age = adult.Age;
                toUpdate.Weight = adult.Weight;
                toUpdate.Height = adult.Height;
                toUpdate.Sex = adult.Sex;

                Console.WriteLine("Update success");
            }
        }
    }
}