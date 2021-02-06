using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string Photo { get; set; }
        public DateTime TimeCreated {get; set;} = DateTime.Now;

        public int UserId {get; set;}

        [ForeignKey("UserId")]
        public User UserOffer {get; set;}
    }
}