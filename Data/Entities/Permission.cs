using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Permissions")]
    public partial class Permission : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; } = String.Empty;


        [NotMapped]
        public DateTime? CreatedOn { get; set; }

        [NotMapped]
        public DateTime? UpdatedOn { get; set; }
    }
}
