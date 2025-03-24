/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
namespace ScaleApp.Services.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        private static readonly string MessageDefault = "The User you are trying to create already exists!";
        private static string _message = string.Empty;

        public UserAlreadyExistsException() : base(MessageDefault)
        {
            
        }

        public UserAlreadyExistsException(string userName) : base(_message)
        {
            _message = $"The User with username {userName} already exists!";
        }
    }
}

