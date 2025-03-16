using DCoreyDuke.CodeBase.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{

    [Table("RoleHasPermissions")]
    public class RoleHasPermissions : IJoinTableObject<Role, Permission>
    {
        [Column]
        public int RoleId { get; set; }
        [Column]
        public int PermissionId { get; set; }
    }

}
