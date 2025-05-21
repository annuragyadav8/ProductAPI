using DtosLayer;

namespace RepositoryLayer
{
    public interface IProductRepository
    {
        List<ProductClass> GetProduct(int id);
        List<ProductClass> AddProduct(ProductClass product);
        List<ProductClass> UpdateProduct(ProductClass product);
        List<ProductClass> DeleteProduct(int id);
        List<ProductClass> GetProducts();
    }
}
