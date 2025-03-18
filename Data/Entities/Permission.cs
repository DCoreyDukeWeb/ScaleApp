/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Permissions")]
    public partial class Permission : IEntity, ITableObject
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }
     
        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
