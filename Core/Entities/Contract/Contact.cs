using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class Contact
    {
        public Contact(string? name)
        {
            Name = name;
        }

        [Column("Id")]
        public int? Id { get; init; }
        public string? Name { get; private set; }
        public ICollection<Contract>? Contracts { get; private set; }

    }
}
