using APITest.Application.DTO;
using APITest.Application.Interfaces.Service;
using APITest.Domain;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace APITest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : BaseController
    {

        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        private readonly IMemoryCache _memoryCache;
        public string cacheKey = "products";

        public ProductController(ILogger<ProductController> logger, IProductService productService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _productService = productService;
            _memoryCache = memoryCache;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] string searchTerm, [FromQuery] string sortBy, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {

            try
            {
                

                List<Product> products = null;
                if (!_memoryCache.TryGetValue(cacheKey, out products))
                {
                    products = await _productService.GetAllProducts();

                    _memoryCache.Set(cacheKey, products,
                        new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(60)));
                }


                if (!string.IsNullOrEmpty(searchTerm))
                {
                    var currentUser = User.Claims.FirstOrDefault(x => x.Type == "id").Value;
                    ProductSearchHistory searchHistory = new ProductSearchHistory() { SearchByUserId = int.Parse(currentUser), SearchKey = searchTerm };
                    var saveSearch = await _productService.SaveProductSearchHistory(searchHistory);
                    products = products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || p.Brand.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (products.Count == 0)
                    {
                        return CustomResult("Search Item Not Found", HttpStatusCode.NotFound);
                    }
                }

                switch (sortBy)
                {
                    case "name":
                        products = products.OrderBy(p => p.Name).ToList();
                        break;
                    case "price":
                        products = products.OrderBy(p => p.Price).ToList();
                        break;

                    default:
                        break;
                }
                if (products.Count > 0)
                {
                    var totalCount = products.Count();
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                    products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                    var result = new
                    {
                        TotalCount = totalCount,
                        TotalPages = totalPages,
                        CurrentPage = page,
                        PageSize = pageSize,
                        Data = products.ToList()
                    };
                    return CustomResult(result, HttpStatusCode.OK);
                }
                return CustomResult(null, HttpStatusCode.OK);


            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllProducts Exception:" + ex.StackTrace);
                return CustomResult("Exception:" + ex.Message, HttpStatusCode.BadRequest);
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductDTO product)
        {
            ResponseDTO responseDTO = new ResponseDTO();
            try
            {

                var response = await _productService.SaveProduct(product);
                if (response)
                {
                    return CustomResult("Success", HttpStatusCode.OK);
                }
                return CustomResult(HttpStatusCode.BadRequest.ToString(), HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                _logger.LogError("SaveProduct Exception:" + ex.StackTrace);
                return CustomResult("Exception:" + ex.Message, HttpStatusCode.BadRequest);
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {

                var response = await _productService.DeleteProduct(id);
                if (response)
                {
                    return CustomResult("Success", HttpStatusCode.OK);
                }
                return CustomResult(HttpStatusCode.BadRequest.ToString(), HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteProduct Exception:" + ex.StackTrace);
                return CustomResult("Exception:" + ex.Message, HttpStatusCode.BadRequest);
            }

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetProductSearchHistoryByUser(int userId)

        {
            try
            {

                var response = await _productService.GetProductSearchHistoryByUser(userId);
                if (response != null)
                {
                    return CustomResult(response, HttpStatusCode.OK);
                }
                return CustomResult("Search Item Not Found", HttpStatusCode.NotFound);

            }
            catch (Exception ex)
            {
                _logger.LogError("GetProductSearchHistoryByUser Exception:" + ex.StackTrace);
                return CustomResult("Exception:" + ex.Message, HttpStatusCode.BadRequest);
            }
        }

    }
}
