using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class JobOfferDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Photo { get; set; }
    }
}