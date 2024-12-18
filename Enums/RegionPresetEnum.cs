using System.ComponentModel;

namespace HIVBackend.Enums
{
    /// <summary>
    /// варианты заполения полей RegionPreset
    /// </summary>
    public enum RegionPresetEnum
    {
        [Description("Все")]
        All = 0,

        [Description("Московская обл.")]
        Mo = 1,

        [Description("Иногородние")]
        Nonresidents = 2,

        [Description("Иностранные")]
        Foreign = 3
    }
}
