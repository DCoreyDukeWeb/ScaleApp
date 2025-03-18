using DCoreyDuke.CodeBase.Auth;
using DCoreyDuke.CodeBase.Interfaces;
using DCoreyDuke.CodeBase.Interfaces.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Roles")]
    public partial class Role : IEntity, ITableObject
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; } 

        public ICollection<Permission> Permissions { get; set; }

        public DateTime? CreatedOn { get; set; }
        
        public DateTime? UpdatedOn { get; set; }
        
    }
}
