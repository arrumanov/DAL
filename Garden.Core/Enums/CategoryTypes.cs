using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Garden.Core.Enums
{
    public enum CategoryTypes
    {
        [Display(Name = "Виноград")]
        Grapes,

        [Display(Name = "Томаты")]
        Tomatoes,

        [Display(Name = "Сад")]
        Orchard,

        [Display(Name = "Остальное")]
        Rest
    }

    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }
}
