using System.Net.Http;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Newtonsoft.Json;
using Xunit;

namespace PublicApi.Tests.IntegrationTests
{
    public class ProductControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ProductControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/Product/GetById?id=1")]
        [InlineData("/api/Product/GetAll")]
        [InlineData("/api/Product/GetPaginatedList?pageNumber=2&pageSize=1")]
        public async Task Get_Endpoints_Return_Ok(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}