using Microsoft.EntityFrameworkCore;
using ReactLearnLabs.Api.Domain.Entities;
using ReactLearnLabs.Api.Infrastructure.Persistence;

namespace ReactLearnLabs.Api.Infrastructure.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(SqliteDbContext context)
    {
        if (await context.Products.AnyAsync()) return;

        var products = new[]
        {
            new Product { Name = "Product 1", Price = 10.0m },
            new Product { Name = "Product 2", Price = 20.0m },
            new Product { Name = "Product 3", Price = 30.0m }
        };

        await context.Products.AddRangeAsync(products);
        await context.SaveChangesAsync();
    }
}