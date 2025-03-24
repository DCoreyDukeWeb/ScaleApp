/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.EntityToModel
{
    /// <summary>
    ///  Represents a scaleticket entity that maps data from a Data.Entities.Scale to a Common.Models.Scale. It
    /// provides access to both the original entity and the mapped model.
    ///</summary>   
    public class ScaleTicket : EntityToModel<Data.Entities.ScaleTicket, Common.Models.ScaleTicket>
    {
        private readonly Data.Entities.ScaleTicket _entity;
        private readonly Common.Models.ScaleTicket _model;

        private ScaleTicket(){ }

        public ScaleTicket(Data.Entities.ScaleTicket entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _entity = entity;
            _model = Map();
        }

        private Common.Models.ScaleTicket Map()
        {
            Scale scale = new Scale(_entity.Scale);
            Common.Models.Scale scaleMapped = scale.Mapped;
            Customer customer = new Customer(_entity.Customer);
            Common.Models.Customer customerMapped = customer.Mapped;
            return new Common.Models.ScaleTicket
            (
                _entity.Id,
                customerMapped.Name,
                scaleMapped,
                customerMapped,
                _entity.TruckId,
                _entity.DriverId,
                _entity.WeightGross,
                _entity.WeightTare,
                _entity.WeightNet,
                _entity.Notes
            );       
        }

        public Data.Entities.ScaleTicket Unmapped => _entity;

        public Common.Models.ScaleTicket Mapped => _model;
    }
}
