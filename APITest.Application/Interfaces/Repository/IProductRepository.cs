using APITest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<bool> SaveProduct(Product product);
        Task<bool> DeleteProduct(int productId);
        Task<List<ProductSearchHistory>> GetProductSearchHistoryByUser(int userId);
        Task<bool> SaveProductSearchHistory(ProductSearchHistory searchHistory);


    }
}
