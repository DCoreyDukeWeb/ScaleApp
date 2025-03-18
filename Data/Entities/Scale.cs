/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Scales")]
    public partial class Scale : IEntity, ITableObject
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public int LocationId { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public virtual Location Location { get; set; }

        [StringLength(256)]
        public string ScaleMfg { get; set; }

        [StringLength(256)]
        public string ScaleModel { get; set; }

        [StringLength(256)]
        public string ScaleSerialNo { get; set; }

        [StringLength(256)]
        public string ScaleProperties { get; set; }

        public DateTime DateInstalled { get; set; }

        [StringLength(256)]
        public string Installer { get; set; }

        public DateTime DateCalibrated { get; set; }

        [StringLength(256)]
        public string CalibratedBy { get; set; }

        public string Notes { get; set; }

      
        public DateTime? CreatedOn { get; set; }
       
        public DateTime? UpdatedOn { get; set; }
    }
}
