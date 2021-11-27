using ApplicationCore.Common.Models;
using ApplicationCore.Common.Models.DTOs;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.Abstractions
{
    public interface IProductService
    {
        public Task<ProductDTO> GetByIdAsync(int id);

        public Task<PaginatedList<ProductDTO>> GetPaginatedListAsync(int page, int pageSize);

        public Task<List<ProductDTO>> GetAllAsync();

        public Task<ProductDTO> UpdateDescriptionAsync(int id, string newDescription);
    }
}
