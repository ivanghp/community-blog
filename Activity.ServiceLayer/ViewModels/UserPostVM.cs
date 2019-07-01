using Activity.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Activity.ServiceLayer.ViewModels
{
    public class UserPostVM
    {
        public User User { get; set; }
        //public Post Post { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "title should be less than 50 characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "description should be less than 200 characters")]
        public string Description { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        //[Required]
        public string Location { get; set; }

        public string Link { get; set; }
    }
}
