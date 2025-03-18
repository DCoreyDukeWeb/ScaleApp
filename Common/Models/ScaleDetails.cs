/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using Common.Interfaces;
using DCoreyDuke.CodeBase.Interfaces;
using System.Text.Json;


namespace Common.Models
{

    [Serializable]
    public class ScaleDetails : IValueObject, IScaleDetails, IJsonSerializable
    {
        private string _manufacturer = string.Empty;
        private string _model = string.Empty;
        private string _serialNumber = string.Empty;
        private Dictionary<string, string> _properties;

        public ScaleDetails()
        {
            _properties = new Dictionary<string, string>();
        }

        public ScaleDetails(string manufacturer, string model, string serialNumber) : this()
        {
            _manufacturer = manufacturer;
            _model = model;
            _serialNumber = serialNumber;
        }

        public ScaleDetails(string manufacturer, string model, string serialNumber, Dictionary<string, string> properties) : this(manufacturer, model, serialNumber)
        {
            _properties = properties;
        }

        public string Manufacturer { get { return _manufacturer; } }
        public string Model { get { return _model; } }
        public string SerialNumber { get { return _serialNumber; } }
        public Dictionary<string, string> Properties { get { return _properties; } }

        public void AddProperty(string key, string value)
        {
            _properties.Add(key, value);
        }
        public void RemoveProperty(string key)
        {
            _properties.Remove(key);
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
