using Common.Interfaces;
using DCoreyDuke.CodeBase.Interfaces;
using DCoreyDuke.CodeBase.Objects;
using DCoreyDuke.CodeBase.ValueObjects.General;
using System.Text.Json;

namespace Common.Models
{

    public class Customer : IDomainModel, IJsonSerializable, ICustomer
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

        public Customer(string name,PhoneNumber phone1, PhoneNumber phone2, PhoneNumber fax, EmailAddress email1, EmailAddress email2, Url url, Location location, DateTime lastContacted, string notes) : this()
        {
            _name = name;
            _contact = new Contact(new Name(name), phone1, phone2, fax, email1, email2, url, location, lastContacted, notes);
            _location = location;
            _notes = notes;
        }
          
        public Customer(string name,PhoneNumber phone1, PhoneNumber phone2, PhoneNumber fax, EmailAddress email1, EmailAddress email2, Url url, string address1, string address2, string city, State state, string zip, DateTime lastContacted, string notes) : this()
        {
            Address address = new Address(address1, address2, string.Empty, city, state, zip);
            Location location = new Location(name, address);
            _name = name;
            _contact = new Contact(new Name(name), phone1, phone2, fax, email1, email2, url, location, lastContacted, notes);
            _location = location;
            _notes = notes;
        }

         public Customer(string name,string phone1, string phone2, string fax, string email1, string email2, string url, string address1, string address2, string city, State state, string zip, DateTime? lastContacted, string notes) : this()
        {
            PhoneNumber phone1Obj = new PhoneNumber(phone1);
            PhoneNumber phone2Obj = new PhoneNumber(phone2);
            PhoneNumber faxObj = new PhoneNumber(fax);
            EmailAddress email1Obj = new EmailAddress(email1);
            EmailAddress email2Obj = new EmailAddress(email2);
            Url urlObj = new Url(url);
            Address address = new Address(address1, address2, string.Empty, city, state, zip);
            Location location = new Location(name, address);
            _name = name;
            _contact = new Contact(new Name(name), phone1Obj, phone2Obj, faxObj, email1Obj, email2Obj, urlObj, location, lastContacted, notes);
            _location = location;
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
