/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{

    [Table("UserHasRoles")]
    public class UserHasRole : IJoinTableObject<User, Role>, IJoinEntity<User, Role>, IEntity, ITableObject
    {
        [Required, Key]
        public int Id { get; set; }
        [Column]
        public int UserId { get; set; }
        [Column]
        public int RoleId { get; set; }
        [Column]
        public DateTime? CreatedOn { get; set; }
        [Column]
        public DateTime? UpdatedOn { get; set; }
    }

}
