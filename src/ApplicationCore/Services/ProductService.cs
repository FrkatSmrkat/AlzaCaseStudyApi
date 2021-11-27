using ApplicationCore.Common.Abstractions;
using ApplicationCore.Common.Models;
using ApplicationCore.Common.Models.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IUriService _uriService;

        public ProductService(IRepository<Product> productRepository, IUriService uriService)
        {
            _productRepository = productRepository;
            _uriService = uriService;
        }

        private ProductDTO MapToDTO(Product product) 
            => new ProductDTO
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                ImgUri = _uriService.GetProductPictureUri(product.ImgUri),
                Price = product.Price
            };


        public async Task<List<ProductDTO>> GetAllAsync()
        {
            var productList = await _productRepository.GetListAsync();

            var result = productList
                .Select(product => MapToDTO(product))
                .ToList();

            return result;
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return null;

            var result = MapToDTO(product);

            return result;
        }

        public async Task<PaginatedList<ProductDTO>> GetPaginatedListAsync(int pageNumber, int pageSize)
        {
            var productCount = await _productRepository.CountAsync();

            var productList = await _productRepository
                .GetListPage(pageNumber, pageSize, x => x.Id);

            var result = productList
                .Select(product => MapToDTO(product))
                .ToList();

            return new PaginatedList<ProductDTO>(result, productCount, pageNumber, pageSize);
        }

        public async Task<ProductDTO> UpdateDescriptionAsync(int id, string newDescription)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return null;

            product.Description = newDescription;

            await _productRepository.UpdateAsync(product);

            return MapToDTO(product);
        }
    }
}
