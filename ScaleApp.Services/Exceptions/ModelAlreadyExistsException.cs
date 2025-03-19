/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace ScaleApp.Services.Exceptions
{
    public class ModelAlreadyExistsException : Exception
    {
        private string _name;
        private static readonly string _message_default = "The Model you are trying to create already exists!";
        private static string _message = string.Empty;

        public ModelAlreadyExistsException() : base(_message_default)
        {
            
        }

        public ModelAlreadyExistsException(string modelName) : base(_message)
        {
            _name = modelName;
            _message = $"The Model with name {_name} already exists!";
        }
    }
}

