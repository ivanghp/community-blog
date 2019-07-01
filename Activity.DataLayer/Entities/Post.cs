using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Activity.DataLayer.Entities
{
    public class Post : BaseEntity
    {
        [Required]
        [StringLength(50, ErrorMessage = "title should be less than 50 characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "description should be less than 200 characters")]
        public string Description { get; set; }

        public string Thumbnail { get; set; }

        //[Required]
        public string Location { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        //public ICollection<Like> Likes { get; set; }

        //public ICollection<Comment> Comments { get; set; }

        //public ICollection<Picture> Pictures { get; set; }

        public string Link { get; set; }

    }
}
