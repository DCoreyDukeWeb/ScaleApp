/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Applications")]
    public partial class Application : IEntity, ITableObject
    {
        [Required]
        [Key]
        public int Id { get; set;}

        [StringLength(256)]
        public string Name { get; set; } = string.Empty;

        [StringLength(256)]
        public string? RelativeUri { get; set; }

        [StringLength(256)]
        public string? IndexUrl { get; set; }

        [StringLength(512)]
        public string? DirectoryPath { get; set; }

        [StringLength(512)]
        public string? RepositoryUrl { get; set; }

        [StringLength(128)]
        public string? ApplicationType { get; set; }

        [StringLength(28)]
        public string? CurrentVersion { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
