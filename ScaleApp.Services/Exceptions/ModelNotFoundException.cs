/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace ScaleApp.Services.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        private string _name = string.Empty;
        private static readonly string _message_default = "The model you requested was not found!";
        private static string _message = string.Empty;

        public ModelNotFoundException() : base(_message_default)
        {
            
        }

        public ModelNotFoundException(string modelName) : base(_message)
        {
            _name = modelName;
            _message = $"The model with name {_name} was not found!";
        }
    }
}
