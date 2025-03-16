using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Users")]
    public partial class User : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Username { get; set; } = String.Empty;

        [StringLength(256)]
        public string Email { get; set; } = String.Empty;

        [StringLength(256)]
        public string Password { get; set; } = String.Empty;

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Roles> Roles { get; set; } = new HashSet<Roles>();

        public virtual ICollection<Roles.UserHasRoles> RolesMaps { get; set; } = new HashSet<Roles.UserHasRoles>();
    }
}
