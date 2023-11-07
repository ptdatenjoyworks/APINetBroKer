using Core.Entities.Attributes;
using Core.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Core.Extensions
{
    public static class EnumExtensions
    {


        public static ProductType GetTypeProduct(this Enum enumValue)
        {
            return enumValue.GetType()
                              .GetMember(enumValue.ToString())
                              .First()
                              .GetCustomAttribute<EnergyUnitTypeAttr>()?.ProductType ?? ProductType.None;
        }
    }
}
