using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Scale : IModel
    {

        private bool _isValid = false;
        private List<string> _validationErrors = new List<string>();
        
        
        public string Name { get; }






 public bool IsValid { get { Validate(); return _validationErrors.Count == 0; } }

        public List<string> ValidationErrors { get { Validate(); return _validationErrors; } }

        private void Validate()
        {
            _validationErrors.Clear();
            if (string.IsNullOrEmpty(_name))
            {
                _validationErrors.Add("Contact Name is required.");
            }
            if(_location == null)
            {
                _validationErrors.Add("Location is required.");
            }
            if (_contact == null)
            {
                _validationErrors.Add("Contact is required.");
            }
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
