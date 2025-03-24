/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace ScaleApp.Services.Exceptions
{
    public class UserNotFoundException : Exception
    {
        private static readonly string MessageDefault = "The User you requested was not found!";
        private static string _message = string.Empty;

        public UserNotFoundException() : base(MessageDefault)
        {
            
        }

        public UserNotFoundException(string userName) : base(_message)
        {
            _message = $"The user with username {userName} was not found!";
        }
    }
}

