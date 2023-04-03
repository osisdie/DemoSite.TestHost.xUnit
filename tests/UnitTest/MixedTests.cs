using DemoSite;
using DemoSite.Database;
using DemoSite.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using UnitTest.Extensions;

namespace UnitTest
{
    // Test classes should not be modified
    public class MixedTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private TestServer _server { get; }

        public MixedTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>());

            _context = _server.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }

        [Fact]
        public async Task post_and_get()
        {
            // Get
            var getResponse = await _server.CreateClient().GetAsync("/product/1");
            var getProduct = await getResponse.Content.ReadAsJsonAsync<Product>();
            getResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);

            // Post
            var prod = new Product { Name = "Smartphone", Weight = 150 };
            var response = await _server.CreateClient().PostAsJsonAsync("/product", prod);
            response.EnsureSuccessStatusCode();


            var getResponse2 = await _server.CreateClient().GetAsync("/product/1");
            var newProduct = await getResponse2.Content.ReadAsJsonAsync<Product>();
            getResponse2.EnsureSuccessStatusCode();

            newProduct.ID.Should().Be(1);
            newProduct.Name.Should().Be(prod.Name);
            newProduct.Weight.Should().Be(prod.Weight);
        }
    }
}
