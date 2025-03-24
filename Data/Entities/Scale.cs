/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Data.Entities
{
    [Table("Scales")]
    public partial class Scale : IEntity, ITableObject
    {

        [Required]
        [Key]
        public int Id { get; set; }

        public int LocationId { get; set; }

        [StringLength(256)]
        public string Name { get; set; } = String.Empty;

        public virtual Location Location { get; set; } = null!;

        [StringLength(256)]
        public string ScaleMfg { get; set; } = String.Empty;

        [StringLength(256)]
        public string ScaleModel { get; set; } = String.Empty;

        [StringLength(256)]
        public string ScaleSerialNo { get; set; } = String.Empty;

        [StringLength(256)]
        public string ScaleProperties { get; set; } = String.Empty;

        public DateTime DateInstalled { get; set; }

        [StringLength(256)]
        public string Installer { get; set; } = String.Empty;

        public DateTime DateCalibrated { get; set; }

        [StringLength(256)]
        public string CalibratedBy { get; set; } = String.Empty;

        public string Notes { get; set; } = String.Empty;

        public virtual ICollection<ScaleTicket> Scales { get; set; } = new HashSet<ScaleTicket>();
        public DateTime? CreatedOn { get => ((IEntity)Location).CreatedOn; set => ((IEntity)Location).CreatedOn = value; }
        public DateTime? UpdatedOn { get => ((IEntity)Location).UpdatedOn; set => ((IEntity)Location).UpdatedOn = value; }
    }
}
