/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Users")]
    public partial class User : IEntity, ITableObject
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Username { get; set; } = String.Empty;

        [StringLength(256)]
        public string Email { get; set; } = String.Empty;

        [StringLength(256)]
        public string Password { get; set; } = String.Empty;

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Role> Roles { get; set; } 

    }
}
