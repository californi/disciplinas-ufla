using LojaOnLine.Domain.Entities;
using Xunit;

namespace LojaOnLine.Tests.Domain;

public class ProductTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_InvalidName_Throws(string? name)
    {
        Assert.Throws<ArgumentException>(() => new Product(name!, 10m, 1));
    }

    [Fact]
    public void Create_NegativePrice_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Product("A", -1m, 0));
    }

    [Fact]
    public void Create_NegativeStock_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Product("A", 0m, -1));
    }

    [Fact]
    public void AddStock_WithPositiveAmount_IncreasesStock()
    {
        var p = new Product("A", 10m, 1);
        p.AddStock(3);
        Assert.Equal(4, p.StockQuantity);
    }

    [Fact]
    public void RemoveStock_Insufficient_Throws()
    {
        var p = new Product("A", 10m, 1);
        Assert.Throws<InvalidOperationException>(() => p.RemoveStock(2));
    }
}
