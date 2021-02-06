using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class JobApplicationDto
    {
        [Required]
        public string AboutUser { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        public string Education { get; set; }
        [Required]
        public string Contact { get; set; }
    }
}