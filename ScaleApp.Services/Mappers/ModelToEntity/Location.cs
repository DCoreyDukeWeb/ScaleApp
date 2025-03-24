/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.ModelToEntity
{
 
    /// <summary>
    /// Represents a location model that maps data from a Common.Models.Location to a Data.Entities.Location. It
    /// includes methods for mapping and accessing the unmapped and mapped entities.
    /// </summary>
    public class Location : ModelToEntity<Common.Models.Location, Data.Entities.Location>
    {
        private readonly Data.Entities.Location _entity = new Data.Entities.Location();
        private readonly Common.Models.Location _model;

        private Location(){ }

        public Location(Common.Models.Location model)
        {
            ArgumentNullException.ThrowIfNull(model);
            _entity = Map();
            _model = model;
        }

        private Data.Entities.Location Map()
        {
            _entity.Id = _model.Id;
            _entity.Name = _model.Name;
            _entity.Address1 = _model.Address.Address1;
            _entity.Address2 = _model.Address.Address2;
            _entity.City = _model.Address.City;
            _entity.State = _model.Address.State.ToString();
            _entity.Zip = _model.Address.PostalCode;
            _entity.Country = _model.Address.Country.ToString();
            _entity.LatLong = _model.LatLng.ToString();
            _entity.Notes = _model.Notes.ToString();

            return _entity;
        }

        public Data.Entities.Location Mapped => _entity;
        public Common.Models.Location Unmapped => _model;
    }
}
