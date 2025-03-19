/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace ScaleApp.Services.Exceptions
{
    public class UserNotFoundException : Exception
    {
        private string _username = string.Empty;
        private static readonly string _message_default = "The User you requested was not found!";
        private static string _message = string.Empty;

        public UserNotFoundException() : base(_message_default)
        {
            
        }

        public UserNotFoundException(string userName) : base(_message)
        {
            _username = userName;
            _message = $"The user with username {_username} was not found!";
        }
    }
}

