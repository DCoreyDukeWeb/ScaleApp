/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Data.Entities
{
    [Table("Contacts")]
    public partial class Contact : IEntity, ITableObject
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public int? LocationId { get; set; }

        [StringLength(256)]
        public string? Name { get; set; }

        [StringLength(28)]
        public string? Phone1 { get; set; }

        [StringLength(28)]
        public string? Phone2 { get; set; }

        [StringLength(28)]
        public string? Fax { get; set; }

        [StringLength(128)]
        public string? Email1 { get; set; }

        [StringLength(128)]
        public string? Email2 { get; set; }

        [StringLength(128)]
        public string? Url { get; set; }

        public virtual Location? Location { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? LastContacted { get; set; }

        public string? Notes { get; set; }

        public virtual ICollection<Customer> Contacts { get; set; } = new HashSet<Customer>();
    }
}
