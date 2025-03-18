/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Locations")]
    public partial class Location : IEntity, ITableObject
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string? Name { get; set; }

        [StringLength(256)]
        public string? Address1 { get; set; }

        [StringLength(256)]
        public string? Address2 { get; set; }

        [StringLength(256)]
        public string? City { get; set; }

        [StringLength(2)]
        public string? State { get; set; }

        [StringLength(12)]
        public string? Zip { get; set; }

        [StringLength(28)]
        public string? Country { get; set; }

        [StringLength(128)]
        public string? LatLong { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string? Notes { get; set; }

       
    }
}
