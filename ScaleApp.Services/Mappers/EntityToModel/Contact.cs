/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Objects;
using ScaleApp.Services.Interfaces;

namespace Services.Mappers.EntityToModel
{
    /// <summary>
    /// Represents a contact entity that maps data from a Data.Entities.Contact to a Common.Models.Contact. It includes
    /// methods for mapping and accessing the entity and model.
    /// </summary>
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

        public Common.Models.Contact Map()
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

        public Data.Entities.Contact Unmapped { get { return _entity; } }

        public Common.Models.Contact Mapped{get{return _model;} }
    }
}
