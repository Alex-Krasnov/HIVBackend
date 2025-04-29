using System.ComponentModel;

namespace HIVBackend.Models.Enums
{
    /// <summary>
    /// варианты заполения полей DiePreset 
    /// </summary>
    public enum DiePresetEnum
    {
        [Description("Все")]
        All = 0,

        [Description("ВИЧ")]
        Hiv = 1 | Aids,

        [Description("Не связанные с ВИЧ")]
        NotHiv = 2,

        [Description("СПИД")]
        Aids = 3
    }
}
