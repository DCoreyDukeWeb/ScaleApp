using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("ScaleTickets")]
    public partial class ScaleTicket : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public int ScaleId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public int CustomerId { get; set; }

        [StringLength(255)]
        public string TruckId { get; set; } = String.Empty;

        [StringLength(255)]
        public string DriverId { get; set; } = String.Empty;

        public int WeightTare { get; set; }

        public int WeightNet { get; set; }

        public int WeightGross { get; set; }

        public int VehicleType { get; set; }

        public string Notes { get; set; } = String.Empty;

        [NotMapped]
        public DateTime? UpdatedOn { get; set; }
    }
}
