using Core.Entities.Enum;

namespace Core.Entities.Attributes
{
    internal class EnergyUnitTypeAttr:Attribute
    {
        public ProductType ProductType { get; private set; }
        public EnergyUnitTypeAttr(ProductType productType) {
            ProductType = productType;
        }
    }
}
