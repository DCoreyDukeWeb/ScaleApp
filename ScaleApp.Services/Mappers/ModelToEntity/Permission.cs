/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.ModelToEntity
{
    /// <summary>
    /// Represents a mapping between a model and an entity for permissions. It initializes with a model and provides
    /// methods to map and access the entity.
    /// </summary>
    public class Permission : ModelToEntity<Common.Models.Permission, Data.Entities.Permission>
    {
        private readonly Data.Entities.Permission _entity = new Data.Entities.Permission();
        private readonly Common.Models.Permission _model;

        private Permission(){ }

        public Permission(Common.Models.Permission model)
        {
            ArgumentNullException.ThrowIfNull(model);
            _entity = Map();
            _model = model;
        }

        private Data.Entities.Permission Map()
        {
            _entity.Id = _model.Id;
            _entity.Name = _model.Name;
            return _entity;
        }

        public Data.Entities.Permission Mapped => _entity;

        public Common.Models.Permission Unmapped => _model;
    }
}
