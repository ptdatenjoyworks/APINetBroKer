using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Requests.Contract
{
    public class SupplierRequest : BaseClass
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Id { get;set; }
    }
}
