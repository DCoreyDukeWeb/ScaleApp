/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Data.Entities
{
    [Table("Permissions")]
    public partial class Permission : IEntity, ITableObject
    {
       [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; } = String.Empty;

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<RoleHasPermissions> Permissions { get; set; } = new HashSet<RoleHasPermissions>();
    }
}
