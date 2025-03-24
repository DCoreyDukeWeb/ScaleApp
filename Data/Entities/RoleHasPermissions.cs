using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Data.Entities
{

    [Table("RoleHasPermissions")]
    public class RoleHasPermissions : IJoinTableObject<Role, Permission>, IJoinEntity<Role, Permission>, IEntity, ITableObject
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public virtual Role Role { get; set; } = null!;

        public virtual Permission Permission { get; set; } = null!;

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }

}
