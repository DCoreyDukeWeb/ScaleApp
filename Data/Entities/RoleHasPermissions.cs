using DCoreyDuke.CodeBase.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{

    [Table("RoleHasPermissions")]
    public class RoleHasPermissions : IJoinTableObject<Role, Permission>, IJoinEntity<Role, Permission>, IEntity, ITableObject
    {
        [Required, Key]
        public int Id { get; set; }
        [Column]
        public int RoleId { get; set; }
        [Column]
        public int PermissionId { get; set; }
        [Column]
        public DateTime? CreatedOn { get; set; }
        [Column]
        public DateTime? UpdatedOn { get; set; }
    }

}
