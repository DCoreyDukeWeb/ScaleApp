using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Roles")]
    public partial class Role : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; } = String.Empty;

        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        [NotMapped]
        public DateTime? CreatedOn { get; set; }
        [NotMapped]
        public DateTime? UpdatedOn { get; set; }
    }
}
