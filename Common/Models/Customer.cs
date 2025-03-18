using DCoreyDuke.CodeBase.Interfaces;
using DCoreyDuke.CodeBase.ValueObjects.General;
using System.Text.Json;

namespace Common.Models
{
    public class Customer : IDomainModel, IJsonSerializable, ILocation, IContact
    {
        private string _name = string.Empty;
        private Location _location;
        private Contact _contact;
        private string _notes = string.Empty;

        private bool _isValid = false;
        private List<string> _validationErrors = new List<string>();

        private Customer()
        { }

        public Customer(string name, Location location, Contact contact) : this()
        {
            _name = name;
            _location = location;
            _contact = contact;
        }

        public Customer(string name, Location location, Contact contact, string notes) : this()
        {
            _name = name;
            _location = location;
            _contact = contact;
            _notes = notes;
        }


        public string Name => _name;
        public Location Location => _location;
        public Contact Contact => _contact;
        public string Notes => _notes;

        public Address Address => ((ILocation)_location).Address;

        public Name ContactName => ((IContact)_contact).ContactName;


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
