/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.Text.Json;
using DCoreyDuke.CodeBase.Interfaces;

namespace ScaleApp.Common.Models
{

    public class Scale : IDomainModel, IJsonSerializable
    {
        private string _name = string.Empty;
        private Location _location;
        private ScaleDetails? _scaleDetails;
        private DateTime? _dateInstalled;
        private DateTime? _dateLastCalibrated;   
        private string? _installedBy = string.Empty;
        private string? _calibratedBy = string.Empty;
        private string? _notes = string.Empty;

        private bool _isValid = false;
        private List<string> _validationErrors = new List<string>();


        private Scale()
        { 
        
        }

        public Scale(string name, Location location, ScaleDetails? scaleDetails, DateTime? dateInstalled, DateTime? dateLastCalibrated, string? installedBy, string? calibratedBy, string? notes) : this()
        {
            _name = name;
            _location = location;
            _scaleDetails = scaleDetails;
            _dateInstalled = dateInstalled;
            _dateLastCalibrated = dateLastCalibrated;
            _installedBy = installedBy;
            _calibratedBy = calibratedBy;
            _notes = notes;
        }

        public Scale(int id, string name, Location location, ScaleDetails? scaleDetails, DateTime? dateInstalled, DateTime? dateLastCalibrated, string? installedBy, string? calibratedBy, string? notes) : this()
        {
            _name = name;
            _location = location;
            _scaleDetails = scaleDetails;
            _dateInstalled = dateInstalled;
            _dateLastCalibrated = dateLastCalibrated;
            _installedBy = installedBy;
            _calibratedBy = calibratedBy;
            _notes = notes;
            Id = id;
        }


        public int Id { get; set; }
        public string Name { get; }
        public Location Location { get; }
        public ScaleDetails? ScaleDetails { get; }
        public DateTime? DateInstalled { get; }
        public DateTime? DateLastCalibrated { get; }
        public string InstalledBy { get; }
        public string CalibratedBy { get; }
        public string Notes { get; }

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
