/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using Common.Interfaces;
using DCoreyDuke.CodeBase.Interfaces;
using DCoreyDuke.CodeBase.Objects;
using DCoreyDuke.CodeBase.ValueObjects.General;
using System.Text.Json;

namespace Common.Models
{

    public class Location : IDomainModel, IJsonSerializable, ILocation
    {
        private string _name = string.Empty;
        private Address _address = new Address(string.Empty, string.Empty, string.Empty, string.Empty, State.Unknown, string.Empty);
        private LatLngStr _latLng = new LatLngStr(string.Empty, string.Empty);
        private string _notes = string.Empty;

        private bool _isValid = false;
        private List<string> _validationErrors = new List<string>();

        private Location()
        {

        }

        public Location(string address, string city, State state, string zip) : this()
        {
            _address = new Address(address, city, state, zip);
        }

        public Location(string name, string address, string city, State state, string zip) : this()
        {
            _name = name;
            _address = new Address(address, city, state, zip);
        }

        public Location(string name, string addressLine1, string addressLine2, string city, State state, string zip) : this()
        {
            _name = name;
            _address = new Address(addressLine1, addressLine2, string.Empty, city, state, zip);
        }

        public Location(Address address) : this()
        {            
            _address = address;
        }

        public Location(string name, Address address) : this()
        {
            _name = name;
            _address = address;
        }

        public Location(string name, Address address, string notes) : this()
        {
            _name = name;
            _address = address;
            _notes = notes;
        }

        public Location(string name, Address address, LatLngStr latLng, string notes) : this()
        {
            _name = name;
            _address = address;
            _latLng = latLng;
            _notes = notes;
        }

        public string Name
        {
            get
            {
                if(string.IsNullOrEmpty(_name))
                {
                    if(_address.Address1 != null)
                    {
                        return _address.Address1.ToString();
                    }
                    else
                    {
                        return "Unknown Value";
                    }
                }
                return _name;
            }
        }

        public Address Address
        {
            get
            {
                return _address;
            }
        }

        public LatLngStr LatLng
        {
            get
            {
                return _latLng;
            }
        }

        public string Notes
        {
            get
            {
                return _notes;
            }
        }

        public bool IsValid { get { Validate(); return _validationErrors.Count == 0; } }

        public List<string> ValidationErrors { get { Validate(); return _validationErrors; } }

        private void Validate()
        {
            _validationErrors.Clear();
            if (string.IsNullOrEmpty(_name))
            {
                _validationErrors.Add("Location Name is required.");
            }
            if (string.IsNullOrEmpty(_address.Address1))
            {
                _validationErrors.Add("Location Address Line 1 Required");
            }
            if (string.IsNullOrEmpty(_address.City))
            {
                _validationErrors.Add("Location City is required.");
            }
            if (_address.State == State.Unknown)
            {
                _validationErrors.Add("Location State is required.");
            }
            if (string.IsNullOrEmpty(_address.PostalCode))
            {
                _validationErrors.Add("Location Zip Code is required.");
            }
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
