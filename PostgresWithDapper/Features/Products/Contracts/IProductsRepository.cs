namespace PostgresWithDapper.Features.Products.Contracts;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetProductsAsync();
    Task CreateProductAsync(Product product);
}
