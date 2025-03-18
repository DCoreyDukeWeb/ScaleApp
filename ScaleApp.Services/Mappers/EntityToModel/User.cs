/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Auth;
using ScaleApp.Services.Interfaces;

namespace Services.Mappers.EntityToModel
{
    /// <summary>
    /// Represents a user by mapping a Data.Entities.User to a Common.Models.User. It initializes the model with user
    /// details and roles.
    /// </summary>
    public class User : EntityToModel<Data.Entities.User, Common.Models.User>
    {
        private Data.Entities.User _entity;
        private Common.Models.User _model;

        private User(){ }

        public User(Data.Entities.User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Data.Entities.User Must Be Provided");
            }
            _entity = entity;
            _model = Map();
        }

        private Common.Models.User Map()
        {
         
            List<AuthRole> _roles = new List<AuthRole>();
            foreach (var role in _entity.Roles)
            {
                _roles.Add(new AuthRole(role.Name));
            }
            return new Common.Models.User
            (
                _entity.Username,
                _entity.Email,
                _entity.Password,
                _roles
           );       
            }

        public Common.Models.User Mapped{get{return _model;} }
    }
}
