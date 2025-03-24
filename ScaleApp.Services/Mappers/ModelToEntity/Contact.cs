/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.ModelToEntity
{
    /// <summary>
    /// Represents a contact that maps between a model and an entity. It initializes with a model and provides access to
    /// the mapped entity.
    /// </summary>
    public class Contact : ModelToEntity<Common.Models.Contact, Data.Entities.Contact>
    {
        private readonly Data.Entities.Contact _entity = new Data.Entities.Contact();
        private readonly Common.Models.Contact _model;

        private Contact()
        {
           
        }

        public Contact(Common.Models.Contact model) : this()
        {
            ArgumentNullException.ThrowIfNull(model);
            _model = model;
            _entity = Map();
        }

        private Data.Entities.Contact Map()
        {
            _entity.LocationId = _model.Location!.Id!;
            return new Data.Entities.Contact();       
        }

        public Data.Entities.Contact Mapped => _entity;

        public Common.Models.Contact Unmapped => _model;
    }
}
