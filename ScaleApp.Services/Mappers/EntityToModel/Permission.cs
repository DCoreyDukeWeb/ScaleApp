/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.EntityToModel
{
    /// <summary>
    /// Represents a mapping between a Data.Entities.Permission and a Common.Models.Permission. It initializes with an
    /// entity and provides a mapped model.
    /// </summary>
    public class Permission : EntityToModel<Data.Entities.Permission, Common.Models.Permission>
    {
        private readonly Data.Entities.Permission _entity;
        private readonly Common.Models.Permission _model;

        private Permission(){ }

        public Permission(Data.Entities.Permission entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _entity = entity;
            _model = Map();
        }

        private Common.Models.Permission Map()
        {
            return new Common.Models.Permission
            (
                _entity.Id,
                _entity.Name
            );       
        }

        public Data.Entities.Permission Unmapped => _entity;

        public Common.Models.Permission Mapped => _model;
    }
}
