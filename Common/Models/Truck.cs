using DCoreyDuke.CodeBase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Models
{
   public class Truck : IDomainModel, IJsonSerializable
    {
        private string _name = string.Empty;
        private string? _vin = string.Empty;
        private string? _licensePlate = string.Empty;
        private string? _make = string.Empty;
        private string? _model = string.Empty;
        private string? _year = string.Empty;
        private string? _dotNumber = string.Empty;
        private string? _color = string.Empty;
        private string? _notes = string.Empty;

        private bool _isValid = false;
        private List<string> _validationErrors = new List<string>();

        private Truck()
        {
        }
        public Truck(string name, string? vin, string? licensePlate, string? make, string? model, string? year, string? dotNumbeer, string? color, string? notes) : this()
        {
            _name = name;
            _vin = vin;
            _licensePlate = licensePlate;
            _make = make;
            _model = model;
            _year = year;
            _dotNumber = dotNumbeer;
            _color = color;
            _notes = notes;
        }
        public string Name { get{return _name; } }
        public string? Vin { get{ return _vin;} }
        public string? LicensePlate { get{ return _licensePlate;} }
        public string? Make { get{ return _make;} }
        public string? Model { get{ return _model;} }
        public string? Year { get{ return _year;} }
        public string? DotNumber { get{ return _dotNumber;} }
        public string? Color { get { return _color;} }
        public string? Notes { get{ return _notes;} }

        public bool IsValid { get { Validate(); return _validationErrors.Count == 0; } }
        public List<string> ValidationErrors { get { Validate(); return _validationErrors; } }
        private void Validate()
        {
            _validationErrors.Clear();
            if (string.IsNullOrEmpty(_name))
            {
                _validationErrors.Add("Truck Name is required.");
            }
        }
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        } 
}
}
