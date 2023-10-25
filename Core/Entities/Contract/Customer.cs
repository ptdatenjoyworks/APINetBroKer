using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class Customer
    {
        public Customer(string? name)
        {
            Name = name;
        }

        [Column("Id")]
        public int? Id { get; init; }
        public string? Name { get; set; }

        public ICollection<Contract>? Contracts { get; private set; }
    }
}
