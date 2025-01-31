using System.ComponentModel;

namespace HIVBackend.Enums
{
    /// <summary>
    /// варианты заполения полей YNA
    /// </summary>
    public enum YNAEnum
    {
        [Description("Все")]
        All = 1,

        [Description("Да")]
        Yes = 2,

        [Description("Нет")]
        No = 3
    }
}
