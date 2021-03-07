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
        private string productStr;
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
                Product product = new Product { Name = "Калоши", Description = "Как найк, но лучше. Обувка века1" };
                var response = await client.PostAsync("/api/products",
                    new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json"));

                //response.EnsureSuccessStatusCode();
                //response.StatusCode.Should().Be(HttpStatusCode.OK);
                //var content = await response.Content.ReadAsStringAsync();

                productStr = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Console.WriteLine(productStr);
                Console.ReadLine();
            }
        }

        //[Fact]
        //public async Task Test_Delete()
        //{
        //    using (var client = new TestClientProvider().Client)
        //    {
        //        Product product = JsonConvert.DeserializeObject<Product>(productStr);
        //        var uri = string.Format(@"/api/values/{0}", product.Id);
        //        using (var response = await client.DeleteAsync(uri))
        //        {
        //            //response.EnsureSuccessStatusCode();
        //            //response.StatusCode.Should().Be(HttpStatusCode.OK);
        //            var result = await response.Content.ReadAsStringAsync();
        //        }
        //    }
        //}

        //тут где то код с тестами на проверку запросов HttpGet("{id}"), HttpPut("{id}" )
        #region
        //... не стал писать, тут и будет идентично HttpDelete("{id}")

        #endregion
    }
}
