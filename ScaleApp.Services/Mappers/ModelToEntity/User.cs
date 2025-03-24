/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Auth;
using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.ModelToEntity
{
    /// <summary>
    /// Represents a user by mapping a Data.Entities.User to a Common.Models.User. It initializes the model with user
    /// details and roles.
    /// </summary>
    public class User : EntityToModel<Data.Entities.User, Common.Models.User>
    {
        private readonly Data.Entities.User _entity = new Data.Entities.User();
        private readonly Common.Models.User _model;

        private User(){ }

        public User(Data.Entities.User entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _entity = entity;
            _model = Map();
        }

        private Common.Models.User Map()
        {
            return new Common.Models.User
            (
                _entity.Username,
                _entity.Email,
                _entity.Password,
                new AuthRole(_entity.Role.Name)
            );       
        }

        public Data.Entities.User Mapped => _entity;
        public Common.Models.User Unmapped => _model;
    }
}
