/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.ModelToEntity
{
     
    public class ScaleTicket : ModelToEntity<Common.Models.ScaleTicket, Data.Entities.ScaleTicket>
    {
        private readonly Data.Entities.ScaleTicket _entity = new Data.Entities.ScaleTicket();
        private readonly Common.Models.ScaleTicket _model;

        private ScaleTicket(){ }

        public ScaleTicket(Common.Models.ScaleTicket model)
        {
            ArgumentNullException.ThrowIfNull(model);
            _entity = Map();
            _model = model;
        }

        private Data.Entities.ScaleTicket Map()
        {
            _entity.Id = _model.Id;
            _entity.ScaleId = _model.Scale.Id;
            _entity.CustomerId = _model.Customer.Id;
            _entity.TruckId =  _model.TruckId;
            _entity.DriverId = _model.DriverId;
            _entity.WeightTare = _model.TareWeight;
            _entity.WeightNet = _model.NetWeight;
            _entity.WeightGross = _model.GrossWeight;
            _entity.VehicleType = 1;
            _entity.Notes = _model.Notes;
            return _entity;
        }

        public Data.Entities.ScaleTicket Mapped => _entity;

        public Common.Models.ScaleTicket Unmapped => _model;
    }
}
