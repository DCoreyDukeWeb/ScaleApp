/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Data.Entities
{
    [Table("Locations")]
    [ComplexType]
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

        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();

        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        public virtual ICollection<Scale> Scales { get; set; } = new HashSet<Scale>();
    }
}
