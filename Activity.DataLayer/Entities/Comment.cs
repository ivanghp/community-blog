using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Activity.DataLayer.Entities
{
    public class Comment : BaseEntity
    {
        [StringLength(150, ErrorMessage = "comment should be less than 150 characters")]
        public string Text { get; set; }

        [ScaffoldColumn(false)]
        public int PostId { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }
    }
}
