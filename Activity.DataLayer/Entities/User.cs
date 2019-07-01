using Activity.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Activity.DataLayer.Entities
{
    public class User : BaseEntity
    {

        [MaxLength(20, ErrorMessage = "user name should not exceed 20 characters"), MinLength(2, ErrorMessage = "user name should not be under 2 characters")]
        [StringLength(20)]
        //[Index(IsUnique = true)]
        public string Name { get; set; }

        [DataType(DataType.Password), MaxLength(20, ErrorMessage = "password should be between 3 and 20 characters long"), MinLength(3, ErrorMessage = "password should be between 3 and 20 characters long")]
        [StringLength(20)]
        public string Password { get; set; }

        //public ICollection<Post> Posts { get; set; }

        //public virtual ICollection<User> Followers { get; set; }

        //public virtual ICollection<User> Following { get; set; }
    }
}
