/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.Text.Json;
using DCoreyDuke.CodeBase.Auth;
using DCoreyDuke.CodeBase.Extensions;
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Common.Models
{
    public class Permission : AuthPermission, IDomainModel, IJsonSerializable, IEquatable<Permission>
    {
        private bool _isValid = false;
        private List<string> _validationErrors = new List<string>();

        public Permission(string name) : base(name)
        {
        }
         public Permission(int id, string name) : base(name)
        {
            Id = id;
        }
        public Permission(AuthPermission permission) : base(permission)
        {
        }

         public int Id { get; set; }

        public bool IsValid { get { Validate(); return _validationErrors.Count == 0; } }

        public List<string> ValidationErrors { get { Validate(); return _validationErrors; } }

        private void Validate()
        {
            _validationErrors.Clear();
            if (string.IsNullOrEmpty(Name))
            {
                _validationErrors.Add("Permission Name is required.");
            }
        }

        private string[] ToArray()
        {
            return new string[] { "Permission", this.Name };
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this.ToArray());
        }

        public override string ToString()
        {
            return this.ToArray()[0] + ": " + this.ToArray()[1];
        }

        public bool Equals(Permission? other)
        {
            if(other == null) return false;
            return this.Name.ToSentenceCase() == other.Name.ToSentenceCase();
        }
    }
}
