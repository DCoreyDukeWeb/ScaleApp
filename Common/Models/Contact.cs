/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using Common.Interfaces;
using DCoreyDuke.CodeBase.Interfaces;
using DCoreyDuke.CodeBase.Objects;
using DCoreyDuke.CodeBase.ValueObjects.General;
using System.Net;
using System.Text.Json;

namespace Common.Models
{

    public class Contact : IDomainModel, IJsonSerializable, IContact
    {
        private string _name = string.Empty;
        private Name _contactName;
        private PhoneNumber? _phone1, _phone2, _fax = null;
        private EmailAddress? _email1, _email2 = null;
        private Url? _url = null;
        private Location? _location = null;
        private DateTime? _lastContacted = null;
        private string? _notes = null;

        private bool _isValid = false;
        private List<string> _validationErrors = new List<string>();

        private Contact()
        {
        }

        public Contact(string name, string phone, string email) : this()
        {
            _contactName = new Name(name);
            _name = _contactName.GetName(NameFormat.FirstNameFirst);
            _phone1 = new PhoneNumber(phone);
            _email1 = new EmailAddress(email);
        }

        public Contact(string name, string phone, string email, Location location) : this()
        {
            _contactName = new Name(name);
            _name = _contactName.GetName(NameFormat.FirstNameFirst);
            _phone1 = new PhoneNumber(phone);
            _email1 = new EmailAddress(email);
            _location = location;
        }

        public Contact(Name name, PhoneNumber? phone1, PhoneNumber? phone2, PhoneNumber? fax,
                       EmailAddress? email1, EmailAddress? email2, Url? url, Location? location,
                       DateTime? lastContacted, string? notes)
        {
            _contactName = name;
            _name = _contactName.GetName(NameFormat.FirstNameFirst);
            _phone1 = phone1;
            _phone2 = phone2;
            _fax = fax;
            _email1 = email1;
            _email2 = email2;
            _url = url;
            _location = location;
            _lastContacted = lastContacted;
            _notes = notes;
        }

        public Contact(string name, string? phone1, string? phone2, string? fax,
                       string? email1, string? email2, string? url, string address,
                       string city, State state, string zip, DateTime? lastContacted, string? notes)
        {
            _contactName = new(name);
            _name = _contactName.GetName(NameFormat.FirstNameFirst);
            _phone1 = new PhoneNumber(phone1) ?? null;
            _phone2 = new PhoneNumber(phone2) ?? null;
            _fax = new PhoneNumber(fax) ?? null; ;
            _email1 = new EmailAddress(email1) ?? null;
            _email2 = new EmailAddress(email2) ?? null;
            _url = new Url(url) ?? null;
            Address _address = new Address(address, city, state, zip);
            _location = new Location(_name, _address);
            _lastContacted = lastContacted ?? DateTime.Now;
            _notes = notes;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public Name ContactName
        {
            get
            {
                return _contactName;
            }
        }
        public PhoneNumber? Phone1
        {
            get
            {
                return _phone1;
            }
        }
        public PhoneNumber? Phone2
        {
            get
            {
                return _phone2;
            }
        }
        public PhoneNumber? Fax
        {
            get
            {
                return _fax;
            }
        }
        public EmailAddress? Email1
        {
            get
            {
                return _email1;
            }
        }
        public EmailAddress? Email2
        {
            get
            {
                return _email2;
            }
        }
        public Url? Url
        {
            get
            {
                return _url;
            }
        }
        public Location? Location
        {
            get
            {
                return _location;
            }
        }
        public DateTime? LastContacted
        {
            get
            {
                return _lastContacted;
            }
        }
        public string? Notes
        {
            get
            {
                return _notes;
            }
        }

        public bool HasPhone => _phone1 != null;
        public bool HasEmail => _email1 != null;
        public bool HasLocation => _location != null;


        public bool IsValid { get { Validate(); return _validationErrors.Count == 0; } }

        public List<string> ValidationErrors { get { Validate(); return _validationErrors; } }

        private void Validate()
        {
            _validationErrors.Clear();
            if (string.IsNullOrEmpty(_name))
            {
                _validationErrors.Add("Contact Name is required.");
            }
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
