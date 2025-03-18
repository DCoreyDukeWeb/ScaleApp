/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
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
}
