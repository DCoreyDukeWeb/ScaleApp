/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Objects;
using ScaleApp.Services.Interfaces;

namespace Services.Mappers.EntityToModel
{
    /// <summary>
    /// Represents a customer entity that maps data from a Data.Entities.Customer to a Common.Models.Customer. It
    /// provides access to both the original entity and the mapped model.
    /// </summary>
    public class Customer : EntityToModel<Data.Entities.Customer, Common.Models.Customer>
    {
        private Data.Entities.Customer _entity;
        private Common.Models.Customer _model;
        private Customer() { }
        public Customer(Data.Entities.Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Data.Entities.Customer Must Be Provided");
            }
            _entity = entity;
            _model = Map();
        }
        public Common.Models.Customer Map()
        {
            return new Common.Models.Customer
            (
                _entity.Name!,
                _entity.Contact!.Phone1!,
                _entity.Contact.Phone2!,
                _entity.Contact.Fax!,
                _entity.Contact.Email1!,
                _entity.Contact.Email2!,
                _entity.Contact.Url!,
                _entity.Location!.Address1!,
                _entity.Location.Address2!,
                _entity.Location.City!,
                Enum.Parse<State>(_entity.Location.State!),
                _entity.Location.Zip!,
                _entity.Contact.LastContacted,
                _entity.Notes!
           );
        }
        public Data.Entities.Customer Unmapped { get { return _entity; } }
        public Common.Models.Customer Mapped { get { return _model; } }
    }
}
