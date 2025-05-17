using Microsoft.EntityFrameworkCore;
using ReactLearnLabs.Api.Endpoints;
using ReactLearnLabs.Api.Infrastructure.Data;
using ReactLearnLabs.Api.Infrastructure.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SqliteDbContext>(options => options.UseSqlite("Data source=products.db"));
builder.Services.AddOpenApi();
/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowStaticWebApp", policy => policy
        .WithOrigins("https://proud-rock-06e1d6303.6.azurestaticapps.net")
        .AllowAnyHeader()
        .AllowAnyMethod());
});*/

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();
await db.Database.EnsureCreatedAsync();
await DbInitializer.SeedAsync(db);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Products ";
        options.DarkMode = false;
    });
}

// app.UseCors("AllowStaticWebApp");
app.UseHttpsRedirection();
app.MapProductEndpoints();

app.Run();