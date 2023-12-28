using Core.Entities.Contract;
using System.Diagnostics.Contracts;

namespace Core.Models.DTO
{
    public class ContractItemDTO
    {
        public ContractItemDTO() { }

        public ContractItemDTO(int? annualUsage, decimal? contractMargin)
        {
            AnnualUsage = annualUsage;
            ContractMargin = contractMargin;
        }

        public ContractItemDTO(DateTime startDate, int? annualUsage, decimal? contractMargin, int? supplierId, string supplierName)
        {
            StartDate = startDate;
            AnnualUsage = annualUsage;
            ContractMargin = contractMargin;
            SupplierId = supplierId;
            SupplierName = supplierName;
        }

        public DateTime StartDate { get; set; }
        public int? AnnualUsage { get; set; }
        public decimal? ContractMargin { get; set; }
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
