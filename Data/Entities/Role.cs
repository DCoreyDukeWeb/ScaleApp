using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Roles")]
    public partial class Role : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; } = String.Empty;

        public virtual ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();

        public virtual ICollection<Permission.RoleHasPermissions> PermissionsMaps { get; set; } = new HashSet<Permission.RoleHasPermissions>();

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();

        public virtual ICollection<Roles.UserHasRoles> UsersMaps { get; set; } = new HashSet<Roles.UserHasRoles>();

        [NotMapped]
        public DateTime? CreatedOn { get; set; }
        [NotMapped]
        public DateTime? UpdatedOn { get; set; }
    }
}
