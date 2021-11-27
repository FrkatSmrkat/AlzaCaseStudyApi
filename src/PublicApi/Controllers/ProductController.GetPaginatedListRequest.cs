using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.Controllers
{
    public class GetPaginatedListRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }
    }
}
