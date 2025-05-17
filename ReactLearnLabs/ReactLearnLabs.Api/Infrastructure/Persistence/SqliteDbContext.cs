using Microsoft.EntityFrameworkCore;
using ReactLearnLabs.Api.Domain.Entities;

namespace ReactLearnLabs.Api.Infrastructure.Persistence;

public class SqliteDbContext(DbContextOptions<SqliteDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
}