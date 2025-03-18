/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Auth;

namespace Services.Mappers.EntityToModel
{
    /// <summary>
    /// Represents a role that maps a Data.Entities.Role to a Common.Models.Role. It initializes with an entity and
    /// converts its permissions.
    /// </summary>
    public class Role : EntityToModel<Data.Entities.Role, Common.Models.Role>
    {
        private Data.Entities.Role _entity;
        private Common.Models.Role _model;

        private Role(){ }

        public Role(Data.Entities.Role entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Data.Entities.Role Must Be Provided");
            }
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
                _entity.Name,
                _permissions
           );       
            }

        public Common.Models.Role Mapped{get{return _model;} }
    }
}
