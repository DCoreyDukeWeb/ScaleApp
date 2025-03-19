/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/
using Common.Models;
using DCoreyDuke.CodeBase.Objects;
using DCoreyDuke.CodeBase.ValueObjects.General;
using ScaleApp.Services.Interfaces;
using System.Text.Json;

namespace Services.Mappers.EntityToModel
{
    /// <summary>
    ///  Represents a scale entity that maps data from a Data.Entities.Scale to a Common.Models.Scale. It
    /// provides access to both the original entity and the mapped model.
    ///</summary>   
    public class Scale : EntityToModel<Data.Entities.Scale, Common.Models.Scale>
    {
        private Data.Entities.Scale _entity;
        private Common.Models.Scale _model;

        public Scale(){ }

        public Scale(Data.Entities.Scale entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Data.Entities.Scale Must Be Provided");
            }
            _entity = entity;
            _model = Map();
        }

        public Common.Models.Scale Map()
        {
            Address address = new Address(_entity.Location.Address1!, _entity.Location.Address2!, string.Empty, _entity.Location.City!, Enum.Parse<State>(_entity.Location.State!), _entity.Location.Zip!);
            Common.Models.Location location = new Common.Models.Location(_entity.Location.Name!, address);
            Dictionary<string, string>? _scaleProperties = JsonSerializer.Deserialize<Dictionary<string, string>>(_entity.ScaleProperties);
            ScaleDetails scaleDetails = new ScaleDetails(_entity.ScaleMfg!, _entity.ScaleModel!, _entity.ScaleSerialNo!, _scaleProperties!);
            return new Common.Models.Scale
            (
                _entity.Name,
                location,
                scaleDetails,
                _entity.DateInstalled,
                _entity.DateCalibrated,
                _entity.Installer,
                _entity.CalibratedBy,
                _entity.Notes
            );       
        }

        public Data.Entities.Scale Unmapped { get { return _entity; } }

        public Common.Models.Scale Mapped{get{return _model;} }
    }
}
