using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetStore.Catalog.Application.Contracts;

namespace NetStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductAppService _productAppService;
        public ProductController(ILogger<ProductController> logger, IProductAppService productAppService)
        {
            _logger = logger;
            _productAppService = productAppService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllProducts([FromQuery] int page, 
                                             [FromQuery] int pageSize)
        {
            var products = await _productAppService.GetProducts(page, pageSize);
            return Ok(products);
        }   
    }
}