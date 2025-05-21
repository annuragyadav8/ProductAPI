using DtosLayer;

namespace ServicesLayer
{
   public interface IProductService
    {
        List<ProductClass> GetProducts();
        List<ProductClass> GetProduct(int id);
        List<ProductClass> AddProduct(ProductClass product);
        List<ProductClass> UpdateProduct(ProductClass product);
        List<ProductClass> DeleteProduct(int id);
    }
}
