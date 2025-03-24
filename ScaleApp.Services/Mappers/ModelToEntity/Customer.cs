/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.ModelToEntity
{
    /// <summary>
    /// Represents a customer, mapping between a model and an entity. It initializes with a model and provides methods
    /// to map to an entity.
    /// </summary>
    public class Customer : ModelToEntity<Common.Models.Customer, Data.Entities.Customer>
    {
        private readonly Data.Entities.Customer _entity = new Data.Entities.Customer();
        private readonly Common.Models.Customer _model;
        private Customer() { }
        public Customer(Common.Models.Customer model) : this()
        {
            ArgumentNullException.ThrowIfNull(model);
            _entity = Map();
            _model = model;
        }
        private Data.Entities.Customer Map()
        {
        
            _entity.Id = _model.Id;
            _entity.LocationId = _model.Location.Id;
            _entity.ContactId = _model.Contact.Id;
            _entity.Name = _model.Name;
            _entity.Notes = _model.Notes;
            _entity.Location = new Location(_model.Location).Mapped;
            _entity.Contact = new Contact(_model.Contact).Mapped;
            return _entity;
        }
        public Data.Entities.Customer Mapped => _entity;
        public Common.Models.Customer Unmapped => _model;
    }
}
