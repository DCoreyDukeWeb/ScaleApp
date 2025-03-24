/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace ScaleApp.Services.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private static readonly string MessageDefault = "The entity you requested was not found!";
        private static string _message = string.Empty;

        public EntityNotFoundException() : base(MessageDefault)
        {
            
        }

        public EntityNotFoundException(int entityId) : base(_message)
        {
            _message = $"The entity with id {entityId} was not found!";
        }
    }
}

