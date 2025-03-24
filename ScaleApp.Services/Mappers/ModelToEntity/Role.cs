/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.ModelToEntity
{
    /// <summary>
    /// Represents a mapping between a model and an entity for roles. It initializes with a model and provides methods
    /// to map and access the corresponding entity.
    /// </summary>
    public class Role : ModelToEntity<Common.Models.Role, Data.Entities.Role>
    {
        private readonly Data.Entities.Role _entity = new Data.Entities.Role();
        private readonly Common.Models.Role _model;

        private Role(){ }

        public Role(Common.Models.Role model)
        {
            ArgumentNullException.ThrowIfNull(model);
            _entity = Map();
            _model = model;
        }

        private Data.Entities.Role Map()
        {
         
            _entity.Id = _model.Id;
            _entity.Name = _model.Name;
            _entity.ApplicationId = _model.ApplicationId;
            foreach(var p in _model.Permissions)
            {
                _entity.Permissions.Add(new Permission(new Common.Models.Permission(p)).Mapped);
            }
            return _entity;
        }

        public Data.Entities.Role Mapped => _entity;
        public Common.Models.Role Unapped => _model;
    }
}
