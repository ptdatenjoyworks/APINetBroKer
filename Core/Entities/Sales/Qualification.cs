using Core.Entities.Contract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Sales
{
    public abstract class Qualification
    {
        public Qualification() { }
        [Column("Id")]
        public int? Id { get; set; }

        //FK SalesProgram
        public int? SalesProgramId { get; set; }
        public SalesProgram? SalesProgram { get; private set; }

        public virtual bool QualificationVerifity(ContractItem contractItem)
        {
            return true;
        }

    }
    public class QualificationDate : Qualification
    {
        public QualificationDate() { }
        public QualificationDate(DateTime? effectiveDate, DateTime? expiryDate, int? saleprogramId)
        {
            EffectiveDate = effectiveDate;
            ExpiryDate = expiryDate;
            SalesProgramId = saleprogramId;
        }

        public DateTime? EffectiveDate { get; private set; }
        public DateTime? ExpiryDate { get; private set; }

        public override bool QualificationVerifity(ContractItem contractItem)
        {
            return EffectiveDate <= contractItem.StartDate && ExpiryDate >= contractItem.StartDate;
        }
    }
    public class QualificationAnnualUsage : Qualification
    {
        public QualificationAnnualUsage() { }
        public QualificationAnnualUsage(int? fromAnnualUsage, int? toAnnualUsage, int? saleprogramId)
        {
            FromAnnualUsage = fromAnnualUsage;
            ToAnnualUsage = toAnnualUsage;
            SalesProgramId = saleprogramId;
        }

        public int? FromAnnualUsage { get; private set; }
        public int? ToAnnualUsage { get; private set; }
        public override bool QualificationVerifity(ContractItem contractItem)
        {
            return FromAnnualUsage <= contractItem.AnnualUsage && ToAnnualUsage >= contractItem.AnnualUsage;
        }
    }
}
