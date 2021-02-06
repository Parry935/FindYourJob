using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string AboutUser { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
        public string Education { get; set; }
        public string Contact { get; set; }
        public int JobOfferId {get; set;}

        [ForeignKey("JobOfferId")]
        public JobOffer JobOffer {get; set;}

        public int UserId {get; set;}

        [ForeignKey("UserId")]
        public User UserApplication {get; set;}
    }
}