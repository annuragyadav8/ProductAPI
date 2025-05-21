using DtosLayer;
using RepositoryLayer;

namespace ServicesLayer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductClass> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<ProductClass> AddProduct(ProductClass product)
        {
            return _productRepository.AddProduct(product);
        }

        public List<ProductClass> DeleteProduct(int id)
        {
            return (_productRepository.DeleteProduct(id));
        }

        public List<ProductClass> GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        public List<ProductClass> UpdateProduct(ProductClass product)
        {
            return _productRepository.UpdateProduct(product);
        }
    }

}
