namespace LojaOnLine.Domain.Entities;

public sealed class Product
{
    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }

    public Product(string name, decimal price, int stockQuantity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));
        if (price < 0)
            throw new ArgumentException("Price must be >= 0", nameof(price));
        if (stockQuantity < 0)
            throw new ArgumentException("Stock must be >= 0", nameof(stockQuantity));

        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public void AddStock(int amount)
    {
        if (amount <= 0) throw new ArgumentException("amount > 0", nameof(amount));
        StockQuantity += amount;
    }

    public void RemoveStock(int amount)
    {
        if (amount <= 0) throw new ArgumentException("amount > 0", nameof(amount));
        if (amount > StockQuantity) throw new InvalidOperationException("insufficient stock");
        StockQuantity -= amount;
    }
}
