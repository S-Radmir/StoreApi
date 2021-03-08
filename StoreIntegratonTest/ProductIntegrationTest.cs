using FluentAssertions;
using Newtonsoft.Json;
using Store.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StoreIntegratonTest
{
    public class ProductIntegrationTest
    {
        private Product product = new Product { Name = "Калоши", Description = "Как найк, но лучше. Обувка века" };
    [Fact]
        public async Task Test_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/products");

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Test_Post()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("/api/products",
                    new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));

                response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }

        [Fact]
        public async Task Test_Delete()
        {
            using (var client = new TestClientProvider().Client)
            {
                var uri = string.Format(@"/api/products/{0}", product.Id);

                using (var response = await client.DeleteAsync(uri))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                    }
                }

            }
        }

        //тут где то код с тестами на проверку запросов HttpGet("{id}"), HttpPut("{id}" )
        #region
        //... не стал писать, тут примерно будет идентично HttpDelete("{id}")

        #endregion
    }
}
