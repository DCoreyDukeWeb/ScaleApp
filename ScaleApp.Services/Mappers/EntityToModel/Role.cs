/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Auth;
using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.EntityToModel
{
    /// <summary>
    /// Represents a role that maps a Data.Entities.Role to a Common.Models.Role. It initializes with an entity and
    /// converts its permissions.
    /// </summary>
    public class Role : EntityToModel<Data.Entities.Role, Common.Models.Role>
    {
        private readonly Data.Entities.Role _entity;
        private readonly Common.Models.Role _model;

        private Role(){ }

        public Role(Data.Entities.Role entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _entity = entity;
            _model = Map();
        }

        private Common.Models.Role Map()
        {
         
            List<AuthPermission> _permissions = new List<AuthPermission>();
            foreach (var p in _entity.Permissions)
            {
                _permissions.Add(new AuthPermission(p.Name));
            }
            return new Common.Models.Role
            (
                _entity.Id,
                _entity.ApplicationId,
                _entity.Name,
                _permissions
            );       
        }

        public Data.Entities.Role Unmapped => _entity;
        public Common.Models.Role Mapped => _model;
    }
}
