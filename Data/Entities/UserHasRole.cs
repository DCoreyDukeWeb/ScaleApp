using DCoreyDuke.CodeBase.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{

    [Table("UserHasRoles")]
    public class UserHasRole : IJoinTableObject<User, Role>
    {
        [Column]
        public int UserId { get; set; }
        [Column]
        public int RoleId { get; set; }
    }

}
