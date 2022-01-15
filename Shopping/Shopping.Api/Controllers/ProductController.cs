using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Shopping.Api.Data;
using Shopping.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductContext _productContext;
        public ProductController(ILogger<ProductController> logger, ProductContext productContext)
        {
            _logger = logger;
            _productContext = productContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            IEnumerable<Product> products = null;
            try
            {
                products = await _productContext.products.Find(p => true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            return products;
        }

    }
}
