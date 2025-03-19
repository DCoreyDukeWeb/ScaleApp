/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Objects;
using DCoreyDuke.CodeBase.ValueObjects.General;
using ScaleApp.Services.Interfaces;
using System.Text.Json;

namespace Services.Mappers.EntityToModel
{
    /// <summary>
    /// Represents a location entity that maps data from a Data.Entities.Location to a Common.Models.Location. It
    /// includes methods for mapping and accessing the unmapped and mapped entities.
    /// </summary>
    public class Location : EntityToModel<Data.Entities.Location, Common.Models.Location>
    {
        private Data.Entities.Location _entity;
        private Common.Models.Location _model;

        private Location(){ }

        public Location(Data.Entities.Location entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Data.Entities.Location Must Be Provided");
            }
            _entity = entity;
            _model = Map();
        }

        public Common.Models.Location Map()
        {

            /*public Location(
             * string name, 
             * string addressLine1, 
             * string addressLine2, 
             * string city, 
             * State state, 
             * string zip) : this()
             */

            
            var _m =  new Common.Models.Location
            (
                _entity.Name!,
                _entity.Address1!,
                _entity.Address2!,
                _entity.City!,
                Enum.Parse<State>(_entity.State!),
                _entity.Zip!
           );  
           if(!string.IsNullOrEmpty(_entity.LatLong))
            {
                LatLngStr? lls = JsonSerializer.Deserialize<LatLngStr>(_entity.LatLong);
                _m.LatLng = lls ?? new LatLngStr(string.Empty, string.Empty);
            }
            return _m;
        }

        public Data.Entities.Location Unmapped { get { return _entity; } }
        public Common.Models.Location Mapped{get{return _model;} }
}
}
