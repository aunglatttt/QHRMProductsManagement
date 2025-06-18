using QHRMProductsManagement.Models;

namespace QHRMProductsManagement.Services
{
    public interface IProductRepository
    {
        Task<PagedList> GetProductsPaged(int pageNumber, int pageSize);
        Task<Product> GetProductById(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
        Task<int> GetTotalProductsCount();
    }
}
