/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace ScaleApp.Services.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        private string _name;
        private static readonly string _message_default = "The User you are trying to create already exists!";
        private static string _message = string.Empty;

        public UserAlreadyExistsException() : base(_message_default)
        {
            
        }

        public UserAlreadyExistsException(string UserName) : base(_message)
        {
            _name = UserName;
            _message = $"The User with username {_name} already exists!";
        }
    }
}

