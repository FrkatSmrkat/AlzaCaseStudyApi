using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.Controllers
{
    public class GetByIdRequest
    {
        [FromQuery(Name = "id")]
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
