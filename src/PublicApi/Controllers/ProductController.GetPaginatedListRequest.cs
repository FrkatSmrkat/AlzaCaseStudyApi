﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.Controllers
{
    public class GetPaginatedListRequest
    {
        [BindProperty(Name ="pageSize")]
        [Required]
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }

        [BindProperty(Name = "pageNumber")]
        [Required]
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }
    }
}
