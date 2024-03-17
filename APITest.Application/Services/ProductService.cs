using APITest.Application.DTO;
using APITest.Application.Interfaces.Repository;
using APITest.Application.Interfaces.Service;
using APITest.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                return await _productRepository.GetAllProducts();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> SaveProduct(ProductDTO product)
        {
            try
            {
                var _product = _mapper.Map<Product>(product);
                return await _productRepository.SaveProduct(_product);
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
                return await _productRepository.DeleteProduct(productId);
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
                return await _productRepository.GetProductSearchHistoryByUser(userId);
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
                return await _productRepository.SaveProductSearchHistory(searchHistory);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
