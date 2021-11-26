using ApplicationCore.Common.Abstractions;
using ApplicationCore.Common.Models;
using ApplicationCore.Common.Models.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlzaCaseStudyApi.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ProductDTO>> GetById([FromQuery] int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        public async Task<ActionResult<PaginatedList<ProductDTO>>> GetPaginatedList(int pageNmuber, int pageSize)
        {
            var products = await _productService.GetPaginatedListAsync(pageNmuber, pageSize);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> UpdateDescription([FromBody] ProductDTO productDTO)
        {
            var product = await _productService.UpdateDescriptionAsync(productDTO.Id, productDTO.Description);
            return Ok(product);
        }
    }
}
