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
    public class GetTests: IDisposable
    {
        private readonly ApplicationDbContext _context;
        private TestServer _server { get; }

        public GetTests()
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
        public async Task get_product_with_id_1_from_endpoint_should_return_data()
        {
            // Setup
            var product = new Product { Name = "Hat", Weight = 45 };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Check
            var response = await _server.CreateClient().GetAsync("/product/1");
            var productAnswer = await response.Content.ReadAsJsonAsync<Product>();

            response.EnsureSuccessStatusCode();

            productAnswer.ID.Should().Be(1);
            productAnswer.Name.Should().Be(product.Name);
            productAnswer.Weight.Should().Be(product.Weight);
        }

        [Fact]
        public async Task get_product_not_found()
        {
            // Empty DB
            var response = await _server.CreateClient().GetAsync("/product/1");
            var product = await response.Content.ReadAsJsonAsync<Product>();

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}
