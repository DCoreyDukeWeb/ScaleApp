/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Data.Entities
{
    [Table("Users")]
    public partial class User : IEntity, ITableObject
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public int RoleId { get; set; }

        public virtual Application Application { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;

        [StringLength(256)]
        public string Username { get; set; } = String.Empty;

        [StringLength(256)]
        public string Email { get; set; } = String.Empty;

        [StringLength(256)]
        public string Password { get; set; } = String.Empty;

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
