using APITest.Application.Interfaces.Repository;
using APITest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly TestDBContext _context;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(TestDBContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var result = await _context.Products.ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> SaveProduct(Product product)
        {
            try
            {
                var _product = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
                if (_product != null)
                {
                    _product.Price = product.Price;
                    _product.Description = product.Description;
                    _product.Name = product.Name;
                    _product.Brand = product.Brand;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    product.IsActive = true;
                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();
                    return true;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var _product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
                if (_product != null)
                {
                    _product.IsActive = false;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ProductSearchHistory>> GetProductSearchHistoryByUser(int userId)
        {
            try
            {
                return await _context.ProductSearchHistories.Where(x => x.SearchByUserId == userId).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SaveProductSearchHistory(ProductSearchHistory searchHistory)
        {
            try
            {

                searchHistory.IsActive = true;
                searchHistory.CreatedDate = DateTime.Now;
                await _context.ProductSearchHistories.AddAsync(searchHistory);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
