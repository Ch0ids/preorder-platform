using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PreorderPlatform.Entity.Entities
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Role name is required.")]
        [StringLength(20, ErrorMessage = "Role name cannot be longer than {1} characters.")]
        public string? Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
