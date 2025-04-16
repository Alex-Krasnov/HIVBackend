using System.ComponentModel;
using System.Reflection;

namespace HIVBackend.Enums
{
    public static class EnumExtension
    {
        /// <summary>
        /// преобразуем енам в List<string> по атрибуту Description
        /// </summary>
        public static List<string> EnumToListOfDescription(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Argument must be of type Enum", nameof(enumType));
            }

            return Enum.GetValues(enumType)
                       .Cast<Enum>()
                       .Select(value => GetEnumDescription(value))
                       .ToList();
        }

        /// <summary>
        /// получаем название параметра из енума в виде строки, полученной из описания вида [Description("мегаописание")]
        /// </summary>
        public static string ToEnumDescriptionNameString(this Enum en)
        {
            var memInfo = en.GetType().GetMember(en.ToString()).Where(x => x.MemberType != MemberTypes.Method).ToList();
            if (!memInfo.Any())
                return string.Empty;
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return !attributes.Any() ? string.Empty : ((DescriptionAttribute)attributes[0]).Description;
        }

        /// <summary>
        /// перобразуем string в enum по DescriptionAttribute
        /// </summary>
        public static T GetEnumFromDescription<T>(string description) where T : Enum
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException(nameof(description));

            var type = typeof(T);

            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                    is DescriptionAttribute attr)
                {
                    if (attr.Description.Equals(description, StringComparison.OrdinalIgnoreCase))
                        return (T)field.GetValue(null)!;
                }
            }

            throw new ArgumentException($"Не найдено соответствие для '{description}' в {typeof(T).Name}");
        }

        private static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
