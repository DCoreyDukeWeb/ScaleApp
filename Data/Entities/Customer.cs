/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Customers")]
    public partial class Customer : IEntity, ITableObject
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public int? LocationId { get; set; }

        public int? ContactId { get; set; }

        [StringLength(256)]
        public string? Name { get; set; }

        public virtual Location? Location { get; set; }

        public virtual Contact? Contact { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string? Notes { get; set; }

        
    }
}
