/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using DCoreyDuke.CodeBase.Auth;
using DCoreyDuke.CodeBase.Interfaces;
using System.Text.Json;


namespace Common.Models
{
    public class Role : AuthRole, IDomainModel, IJsonSerializable, IEquatable<Role>
    {
        private bool _isValid = false;
        private List<string> _validationErrors = new List<string>();

        public Role(string name) : base(name)
        {
        }
        public Role(AuthRole role) : base(role)
        {
        }
        public Role(string name, List<AuthPermission> permissions) : base(name, permissions)
        {
        }


        public bool IsValid { get { Validate(); return _validationErrors.Count == 0; } }

        public List<string> ValidationErrors { get { Validate(); return _validationErrors; } }

        private void Validate()
        {
            _validationErrors.Clear();
            if (string.IsNullOrEmpty(Name))
            {
                _validationErrors.Add("Role Name is required.");
            }
        }

        private string[] ToArray()
        {
            return new string[] { "Role", this.Name };
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this.ToArray());
        }

        public override string ToString()
        {
            return this.ToArray()[0] + ": " + this.ToArray()[1];
        }

        public bool Equals(Role? other)
        {
            if(other == null) return false;
            return this.Name.ToLower() == other.Name.ToLower();
        }
    }
}
