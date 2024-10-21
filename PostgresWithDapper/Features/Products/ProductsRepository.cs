using Dapper;
using PostgresWithDapper.Data;
using PostgresWithDapper.Features.Products.Contracts;

namespace PostgresWithDapper.Features.Products;

public class ProductsRepository(IDbConnectionFactory dbConnectionFactory) : IProductsRepository
{
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        using var db = await dbConnectionFactory.CreateConnectionAsync();

        return await db.QueryAsync<Product>("SELECT * FROM products");
    }

    public async Task CreateProductAsync(Product product)
    {
        using var db = await dbConnectionFactory.CreateConnectionAsync();

        await db.ExecuteAsync("INSERT INTO products (name) VALUES (@name)", new { name = "Product 1" });
    }
}
