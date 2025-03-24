/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Data.Entities
{
    [Table("ScaleTickets")]
    public partial class ScaleTicket : IEntity, ITableObject
    {
       [Required]
        [Key]
        public int Id { get; set; }

        public int ScaleId { get; set; }

        public virtual Scale Scale { get; set; } = null!;

        public DateTime? CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [StringLength(256)]
        public string TruckId { get; set; } = String.Empty;

        [StringLength(256)]
        public string DriverId { get; set; } = String.Empty;

        public int WeightTare { get; set; }

        public int WeightNet { get; set; }

        public int WeightGross { get; set; }

        public int VehicleType { get; set; }

        public string Notes { get; set; } = String.Empty;
        public DateTime? UpdatedOn { get => ((IEntity)Scale).UpdatedOn; set => ((IEntity)Scale).UpdatedOn = value; }
    }
}
