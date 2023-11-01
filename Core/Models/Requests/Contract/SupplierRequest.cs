using System.ComponentModel.DataAnnotations;

namespace Core.Models.Requests.Contract
{
    public class SupplierRequest
    {
        [Required]
        public string? Name { get; set; }
    }
}
