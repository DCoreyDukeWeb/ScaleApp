/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System.ComponentModel.DataAnnotations;

namespace ScaleApp.Common.Enums
{
    [Serializable]
    public enum VehicleTypes
    {
        [Display(Name = "Combination Vehicle")]
        CombinationVehicle = 0,
        [Display(Name = "Straight Truck")]
        StraightTruck = 1,
        [Display(Name = "Dump Truck")]
        DumpTruck = 2,
        [Display(Name = "Other")]
        Other = 3
    }
}
