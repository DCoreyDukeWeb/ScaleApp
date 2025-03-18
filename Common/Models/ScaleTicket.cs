using DCoreyDuke.CodeBase.Interfaces;
using System.Text.Json;

namespace Common.Models
{

    public class ScaleTicket : IModel
    {

        private string _name = string.Empty;
        private Scale _scale;
        private Customer _customer;
        private string _truckId = string.Empty;
        private string _driverId = string.Empty;
        private int _grossWeight = 0;
        private int _tareWeight = 0;
        private int _netWeight = 0;
        private string _notes = string.Empty;

        private bool _isValid = false;
        private List<string> _validationErrors = new List<string>();
        
        private ScaleTicket()
        {
        }

        public ScaleTicket(string name, Scale scale, Customer customer, string truckId, string driverId, int grossWeight, int tareWeight, int netWeight, string notes) : this()
        {
            _name = name;
            _scale = scale;
            _customer = customer;
            _truckId = truckId;
            _driverId = driverId;
            _grossWeight = grossWeight;
            _tareWeight = tareWeight;
            _netWeight = netWeight;
            _notes = notes;
        }

        public string Name { get{ return _name;} }
        public Scale Scale { get { return _scale; } }
        public Customer Customer { get { return _customer; } }
        public string TruckId { get { return _truckId; } }
        public string DriverId { get { return _driverId; } }
        public int GrossWeight { get { return _grossWeight; } }
        public int TareWeight { get { return _tareWeight; } }
        public int NetWeight { get { return _netWeight; } }
        public string Notes { get { return _notes; } }

        public int CalculateNetWeight()
        {
            return _grossWeight - _tareWeight;
        }

        public bool IsValid { get { Validate(); return _validationErrors.Count == 0; } }

        public List<string> ValidationErrors { get { Validate(); return _validationErrors; } }

        private void Validate()
        {
            _validationErrors.Clear();
            if (string.IsNullOrEmpty(_name))
            {
                _validationErrors.Add("Scale Name is required.");
            }
            if (_location == null)
            {
                _validationErrors.Add("Scale Location is required.");
            }
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
