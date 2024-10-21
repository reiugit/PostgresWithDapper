
using PostgresWithDapper.Features.Products.Contracts;

namespace PostgresWithDapper.Features.Products;

public class ProductsService(IProductsRepository productsRepository) : IProductsService
{
    public async Task<IEnumerable<Product>> GetProductsAsync()
        => await productsRepository.GetProductsAsync();

    public async Task CreateProductAsync(Product product)
        => await productsRepository.CreateProductAsync(product);
}
