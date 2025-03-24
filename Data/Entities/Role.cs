using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Data.Entities
{
    [Table("Roles")]
    public partial class Role : IEntity, ITableObject
    {
       
        [Required]
        [Key]
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; } = null!;

        [StringLength(256)]
        public string Name { get; set; } = String.Empty;

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<RoleHasPermissions> RoleHasPermissions { get; set; } = new HashSet<RoleHasPermissions>();

        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();

        public virtual ICollection<Permission> Permissions { get; set; }
        
    }
}
