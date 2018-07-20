using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InefficientCode
{
    public class Networking
    {
        public async Task<IEnumerable<HttpResponseMessage>> GetResourcesAsync()
        {
            HttpResponseMessage resourceOne = await GetResource1Async();
            HttpResponseMessage resourceTwo = await GetResource2Async();

            var resources = new[]
            {
                resourceOne,
                resourceTwo
            };

            return resources;
        }

        private async Task<HttpResponseMessage> GetResource1Async()
        {
            using (var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.somewebsite.com")
            })
            {
                return await httpClient.GetAsync("one");
            }
        }

        private async Task<HttpResponseMessage> GetResource2Async()
        {
            using (var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://www.somewebsite.com")
            })
            {
                return await httpClient.GetAsync("two");
            }
        }
    }
}