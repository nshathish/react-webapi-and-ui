using Microsoft.EntityFrameworkCore;
using ReactLearnLabs.Api.Domain.Entities;
using ReactLearnLabs.Api.Infrastructure.Persistence;

namespace ReactLearnLabs.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/products").WithTags("Products");

        group.MapGet("/", async (SqliteDbContext db) => await db.Products.ToListAsync());

        group.MapGet("{id:int}",
            async (int id, SqliteDbContext db) => await db.Products.FindAsync(id) is { } product
                ? Results.Ok((object?)product)
                : Results.NotFound());
        
        group.MapPost("/", async (Product product, SqliteDbContext db) =>
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Results.Created($"/api/products/{product.Id}", product);
        });
        
        group.MapPut("{id:int}", async (int id, Product updatedProduct, SqliteDbContext db) =>
        {
            var product = await db.Products.FindAsync(id);
            if (product is null) return Results.NotFound();
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
        
        group.MapDelete("{id:int}", async (int id, SqliteDbContext db) =>
        {
            var product = await db.Products.FindAsync(id);
            if (product is null) return Results.NotFound();
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}