using ProductApi.Models;
using Xunit;
namespace ProductApi.Tests
{
public class ProductTests
{
[Fact]
public void CanCreateProduct()
{
var p = new Product { Name = "Test", Price = 123 };
Assert.Equal("Test", p.Name);
Assert.Equal(123, p.Price);
}
}
}