/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.Collections.Specialized;
using System.Text.Json;
using DCoreyDuke.CodeBase.Auth;
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Common.Models
{
    public class User : AuthUser, IDomainModel, IJsonSerializable, IEquatable<User>
    {

        private readonly List<string> _validationErrors = [];
        
        public User(AuthUser user) : base(user)
        {
        }
        public User(string username, string email, string password) : base(username, email, password)
        {
        }

         public User(string username, string email, string password, AuthRole role) : base(username, email, password, role)
        {
        }
         public User(int id, string username, string email, string password, AuthRole role) : base(username, email, password, role)
        {
            Id = id;
        }

         public int Id { get; set; }

        public string Name => Username;

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
