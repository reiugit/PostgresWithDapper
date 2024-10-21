namespace PostgresWithDapper.Features.Products.Contracts;

public interface IProductsService
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task CreateProductAsync(Product product);
}
