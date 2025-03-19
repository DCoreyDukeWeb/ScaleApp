/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace ScaleApp.Services.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private int _id;
        private static readonly string _message_default = "The entity you requested was not found!";
        private static string _message = string.Empty;

        public EntityNotFoundException() : base(_message_default)
        {
            
        }

        public EntityNotFoundException(int entityId) : base(_message)
        {
            _id = entityId;
            _message = $"The entity with id {_id} was not found!";
        }
    }
}

