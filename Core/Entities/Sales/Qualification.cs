using Core.Entities.Contract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Sales
{
    public class Qualification
    {
        [Column("Id")]
        public int? Id { get; set; }

        //FK SalesProgram
        public int? SalesProgramId { get; private set; }
        public SalesProgram? SalesProgram { get; private set; }

        public virtual bool QualificationVerifity(ContractItem contractItem)
        {
            return true;
        }

    }
    public class QualificationDate : Qualification
    {
        public DateTime? EffectiveDate { get; private set; }
        public DateTime? ExpiryDate { get; private set; }

        public override bool QualificationVerifity(ContractItem contractItem)
        {
            return EffectiveDate <= contractItem.StartDate && ExpiryDate >= contractItem.StartDate;
        }
    }
    public class QualificationAnnualUsage : Qualification
    {
        public int? FromAnnualUsage { get; private set; }
        public int? ToAnnualUsage { get; private set; }
        public override bool QualificationVerifity(ContractItem contractItem)
        {
            return FromAnnualUsage <= contractItem.AnnualUsage && ToAnnualUsage >= contractItem.AnnualUsage;
        }
    }


}
