using PostgresWithDapper.Data;
using PostgresWithDapper.Features.Products;
using PostgresWithDapper.Features.Products.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new PostgresConnectionFactory(
        builder.Configuration.GetConnectionString("PostgresConnection")!));

builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

var app = builder.Build();

// First: start Postgres-database with "docker compose up"
await app.SeedData();

app.MapGet("/", async (IProductsService productsService)
    => await productsService.GetProductsAsync());

app.Run();
