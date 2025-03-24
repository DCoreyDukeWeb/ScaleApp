/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace ScaleApp.Services.Exceptions
{
    public class ModelNotFoundException : Exception
    {
        private static readonly string MessageDefault = "The model you requested was not found!";
        private static string _message = string.Empty;

        public ModelNotFoundException() : base(MessageDefault)
        {
            
        }

        public ModelNotFoundException(string modelName) : base(_message)
        {
            _message = $"The model with name {modelName} was not found!";
        }
    }
}
