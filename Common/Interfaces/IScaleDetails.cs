/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

namespace Common.Interfaces
{
    public interface IScaleDetails
    {
        string Manufacturer { get; }
        string Model { get; }
        Dictionary<string, string> Properties { get; }
        string SerialNumber { get; }

        void AddProperty(string key, string value);
        void RemoveProperty(string key);
    }
}
