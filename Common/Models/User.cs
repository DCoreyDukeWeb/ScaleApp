/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Auth;
using DCoreyDuke.CodeBase.Interfaces;
using System.Collections.Specialized;
using System.Text.Json;


namespace Common.Models
{
    public class User : AuthUser, IDomainModel, IJsonSerializable, IEquatable<User>
    {

        private bool _isValid = false;
        private List<string> _validationErrors = new List<string>();
        
        public User(AuthUser user) : base(user)
        {
        }
        public User(string username, string email, string password) : base(username, email, password)
        {
        }

         public User(string username, string email, string password, List<AuthRole> roles) : base(username, email, password, roles)
        {
        }

        public string Name { get { return Username; } }

        public bool IsValid { get { Validate(); return _validationErrors.Count == 0; } }

        public List<string> ValidationErrors { get { Validate(); return _validationErrors; } }

        private void Validate()
        {
            _validationErrors.Clear();
            if (string.IsNullOrEmpty(Username))
            {
                _validationErrors.Add("Username is required.");
            }
        }

        private NameValueCollection ToArray()
        {
            return new NameValueCollection() 
            {   
                { "Username", this.Username },
                { "Email", this.Email },
                { "Password", this.Password },
                { "Roles", string.Join(",", this.Roles.Select(r => r.Name)) }
            };
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this.ToArray());
        }

        public override string ToString()
        {
            return this.ToJson();
        }

        public bool Equals(User? other)
        {
            if(other == null) return false;
            return this.Name == other.Name;
        }
    }
}
