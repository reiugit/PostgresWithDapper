using Dapper;
using PostgresWithDapper.Data;
using PostgresWithDapper.Features.Products;
using PostgresWithDapper.Features.Products.Contracts;

public static class DbExtensions
{
    public static async Task SeedData(this WebApplication app)
    {
        await EnsureProductsTableCreated(app);

        var scope = app.Services.CreateScope();
        var productsService = scope.ServiceProvider.GetRequiredService<IProductsService>();

        await productsService.CreateProductAsync(new Product { Name = "Product 1" });
        await productsService.CreateProductAsync(new Product { Name = "Product 2" });
    }

    private static async Task EnsureProductsTableCreated(WebApplication app)
    {
        var dbConnectionFactory = app.Services.GetRequiredService<IDbConnectionFactory>();
        using var db = await dbConnectionFactory.CreateConnectionAsync();

        await db.ExecuteAsync("CREATE TABLE IF NOT EXISTS products (id serial PRIMARY KEY, name VARCHAR(50))");
        await db.ExecuteAsync("DELETE FROM products");
    }
}
