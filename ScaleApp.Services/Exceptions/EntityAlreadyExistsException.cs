/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace ScaleApp.Services.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        private int _id;
        private static readonly string MessageDefault = "The entity you are trying to create already exists!";
        private static string _message = string.Empty;

        public EntityAlreadyExistsException() : base(MessageDefault)
        {
            
        }

        public EntityAlreadyExistsException(int entityId) : base(_message)
        {
            _id = entityId;
            _message = $"The entity with id {_id} already exists!";
        }
    }
}

