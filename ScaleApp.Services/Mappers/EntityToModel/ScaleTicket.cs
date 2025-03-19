/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using ScaleApp.Services.Interfaces;

namespace Services.Mappers.EntityToModel
{
    /// <summary>
    ///  Represents a scaleticket entity that maps data from a Data.Entities.Scale to a Common.Models.Scale. It
    /// provides access to both the original entity and the mapped model.
    ///</summary>   
    public class ScaleTicket : EntityToModel<Data.Entities.ScaleTicket, Common.Models.ScaleTicket>
    {
        private Data.Entities.ScaleTicket _entity;
        private Common.Models.ScaleTicket _model;

        private ScaleTicket(){ }

        public ScaleTicket(Data.Entities.ScaleTicket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Data.Entities.ScaleTicket Must Be Provided");
            }
            _entity = entity;
            _model = Map();
        }

        public Common.Models.ScaleTicket Map()
        {
            Scale scale = new Scale(_entity.Scale);
            Common.Models.Scale scale_mapped = scale.Map();
            Customer customer = new Customer(_entity.Customer);
            Common.Models.Customer customer_mapped = customer.Map();
            return new Common.Models.ScaleTicket
            (
                customer_mapped.Name,
                scale_mapped,
                customer_mapped,
                _entity.TruckId,
                _entity.DriverId,
                _entity.WeightGross,
                _entity.WeightTare,
                _entity.WeightNet,
                _entity.Notes
            );       
        }

        public Data.Entities.ScaleTicket Unmapped { get { return _entity; } }

        public Common.Models.ScaleTicket Mapped{get{return _model;} }
    }
}
