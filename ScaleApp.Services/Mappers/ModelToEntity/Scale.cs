/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.Text.Json;
using ScaleApp.Services.Interfaces;

namespace ScaleApp.Services.Mappers.ModelToEntity
{
    /// <summary>
    /// Represents a mapping between a model and an entity for scales. It initializes with a model and provides methods
    /// to map it to an entity.
    /// </summary>
    public class Scale : ModelToEntity<Common.Models.Scale, Data.Entities.Scale>
    {
        private readonly Data.Entities.Scale _entity = new Data.Entities.Scale();
        private readonly Common.Models.Scale _model;

        public Scale(){ }

        public Scale(Common.Models.Scale model)
        {
            ArgumentNullException.ThrowIfNull(model);
            _entity = Map();
            _model = model;
        }

        private Data.Entities.Scale Map()
        {
            _entity.Id = _model.Id;
            _entity.LocationId = _model.Location.Id;
            _entity.Location = new Location(_model.Location).Mapped;
            _entity.ScaleMfg = _model.ScaleDetails!.Manufacturer;
            _entity.ScaleModel = _model.ScaleDetails!.Model;
            _entity.ScaleSerialNo = _model.ScaleDetails!.SerialNumber;
            _entity.ScaleProperties = JsonSerializer.Serialize(_model.ScaleDetails.Properties);
            _entity.DateInstalled = (DateTime)_model.DateInstalled!;
            _entity.Installer = _model.InstalledBy;
            _entity.DateCalibrated = (DateTime)_model.DateLastCalibrated!;
            _entity.CalibratedBy = _model.CalibratedBy;
            _entity.Notes = _model.Notes;
            _entity.Name = _model.Name;
            return _entity;
        }

        public Data.Entities.Scale Mapped => _entity;
        public Common.Models.Scale Unmapped => _model;
    }
}
