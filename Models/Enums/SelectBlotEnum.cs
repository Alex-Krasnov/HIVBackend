using System.ComponentModel;

namespace HIVBackend.Models.Enums
{
    /// <summary>
    /// варианты заполения полей SelectBlot
    /// </summary>
    public enum SelectBlotEnum
    {
        [Description("Все")]
        All = 0,

        [Description("Первый")]
        first = 1,

        [Description("Последний")]
        last = 2,

        [Description("Перв.и посл.")]
        firstAndLast = 3
    }
}
