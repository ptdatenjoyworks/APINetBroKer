using Core.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Sales
{
    public class DateConfig
    {
        [Column("Id")]
        public int? Id { get; set; }

        //FK Commision
        public int? CommisionId { get; set; }
        public Commision? Commision { get; set; }


        public ControlDateType ControlDateType { get; set; }
        public ControlDateModifierType ControlDateModifierType { get; set; }
        public ControlDateOffsetType ControlDateOffsetType { get; set; }
        public int? ControlDateOffsetValue { get; set; }
    }
}
