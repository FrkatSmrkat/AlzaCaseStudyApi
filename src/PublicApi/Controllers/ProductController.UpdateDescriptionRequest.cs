using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.Controllers
{
    public class UpdateDescriptionRequest
    {
        [BindProperty(Name = "id")]
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [BindProperty(Name ="description")]
        [Required]
        [StringLength(1_000)]
        public string Description { get; set; }
    }
}
