using Core.Entities.Attributes;
using Microsoft.VisualBasic;

namespace Core.Entities.Enum
{
    public enum EnergyUnitType
    {
        None,
        [EnergyUnitTypeAttr(ProductType.Gas)]
        CCF,
        [EnergyUnitTypeAttr(ProductType.Gas)]
        THM,
        [EnergyUnitTypeAttr(ProductType.Gas)]
        MCF,
        [EnergyUnitTypeAttr(ProductType.Elec)]
        KWH,
        [EnergyUnitTypeAttr(ProductType.Elec)]
        MWH
    }
}
