using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Teledok.Models.Enums.Extentions;

public static class EnumExtentions
{
    public static string? GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
            .GetMember(enumValue.ToString())
            .First()
            .GetCustomAttribute<DisplayAttribute>()
            ?.Name;
    }
}