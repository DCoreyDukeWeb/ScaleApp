/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace ScaleApp.Services.Exceptions
{
    public class ModelAlreadyExistsException : Exception
    {
        private static readonly string MessageDefault = "The Model you are trying to create already exists!";
        private static string _message = string.Empty;

        public ModelAlreadyExistsException() : base(MessageDefault)
        {
            
        }

        public ModelAlreadyExistsException(string modelName) : base(_message)
        {
            _message = $"The Model with name {modelName} already exists!";
        }
    }
}

