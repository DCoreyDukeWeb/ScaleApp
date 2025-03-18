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
    /// Represents a mapping between a Data.Entities.Permission and a Common.Models.Permission. It initializes with an
    /// entity and provides a mapped model.
    /// </summary>
    public class Permission : EntityToModel<Data.Entities.Permission, Common.Models.Permission>
    {
        private Data.Entities.Permission _entity;
        private Common.Models.Permission _model;

        private Permission(){ }

        public Permission(Data.Entities.Permission entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Data.Entities.Permission Must Be Provided");
            }
            _entity = entity;
            _model = Map();
        }

        private Common.Models.Permission Map()
        {
            return new Common.Models.Permission
            (
                _entity.Name
           );       
            }

        public Common.Models.Permission Mapped{get{return _model;} }
    }

     public class Contact : EntityToModel<Data.Entities.Contact, Common.Models.Contact>
    {
        private Data.Entities.Contact _entity;
        private Common.Models.Contact _model;

        private Contact(){ }

        public Contact(Data.Entities.Contact entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Data.Entities.Contact Must Be Provided");
            }
            _entity = entity;
            _model = Map();
        }

        private Common.Models.Contact Map()
        {
            /*
             *public Contact(string name, string? phone1, string? phone2, string? fax,
                       string? email1, string? email2, string? url, string address1, string address2,
                       string city, State state, string zip, DateTime? lastContacted, string? notes)
        { 
             * 
            */
            return new Common.Models.Contact
            (
                _entity.Name!,
                _entity.Phone1,
                _entity.Phone2,
                _entity.Fax,
                _entity.Email1,
                _entity.Email2,
                _entity.Url,
                _entity.Location!.Address1!,
                _entity.Location.Address2!,
                _entity.Location.City!,
                Enum.Parse<State>(_entity.Location.State!),
                _entity.Location.Zip!,
                _entity.LastContacted,
                _entity.Notes
           );       
        }

        public Common.Models.Contact Mapped{get{return _model;} }
    }

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

        private Common.Models.Location Map()
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

        public Common.Models.Location Mapped{get{return _model;} }
}
}
