/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.Text.Json;
using DCoreyDuke.CodeBase.ValueObjects;
using DCoreyDuke.CodeBase.ValueObjects.General;
using ScaleApp.Common.Models;
using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.EntityToModel
{
    /// <summary>
    ///  Represents a scale entity that maps data from a Data.Entities.Scale to a Common.Models.Scale. It
    /// provides access to both the original entity and the mapped model.
    ///</summary>   
    public class Scale : EntityToModel<Data.Entities.Scale, Common.Models.Scale>
    {
        private readonly Data.Entities.Scale _entity;
        private readonly Common.Models.Scale _model;

        public Scale(){ }

        public Scale(Data.Entities.Scale entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _entity = entity;
            _model = Map();
        }

        private Common.Models.Scale Map()
        {
            Address address = new Address(_entity.Location.Address1!, _entity.Location.Address2!, string.Empty, _entity.Location.City!, Enum.Parse<State>(_entity.Location.State!), _entity.Location.Zip!);
            Common.Models.Location location = new Common.Models.Location(_entity.Location.Name!, address);
            Dictionary<string, string>? scaleProperties = JsonSerializer.Deserialize<Dictionary<string, string>>(_entity.ScaleProperties);
            ScaleDetails scaleDetails = new ScaleDetails(_entity.ScaleMfg!, _entity.ScaleModel!, _entity.ScaleSerialNo!, scaleProperties!);
            return new Common.Models.Scale
            (
                _entity.Id,
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

        public Data.Entities.Scale Unmapped => _entity;

        public Common.Models.Scale Mapped => _model;
    }
}
