using ApplicationCore.Common.Abstractions;
using ApplicationCore.Common.Models;
using ApplicationCore.Common.Models.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublicApi.Controllers
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
        public async Task<ActionResult<ProductDTO>> GetById([FromQuery] GetByIdRequest request)
        {
            var product = await _productService.GetByIdAsync(request.Id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<ProductDTO>>> GetPaginatedList([FromQuery] GetPaginatedListRequest request)
        {
            var products = await _productService.GetPaginatedListAsync(request.PageNumber, request.PageSize);

            return Ok(products);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductDTO>> UpdateDescription([FromBody] UpdateDescriptionRequest request)
        {
            var product = await _productService.UpdateDescriptionAsync(request.Id, request.Description);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
