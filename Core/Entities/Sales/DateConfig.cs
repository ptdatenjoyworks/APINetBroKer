using Core.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Sales
{
    public class DateConfig
    {
        public DateConfig(int? commisionId, ControlDateType controlDateType, ControlDateModifierType controlDateModifierType, ControlDateOffsetType controlDateOffsetType, int? controlDateOffsetValue)
        {
            CommisionId = commisionId;
            ControlDateType = controlDateType;
            ControlDateModifierType = controlDateModifierType;
            ControlDateOffsetType = controlDateOffsetType;
            ControlDateOffsetValue = controlDateOffsetValue;
        }

        [Column("Id")]
        public int Id { get; set; }

        //FK Commision
        public int? CommisionId { get; private set; }
        public Commision? Commision { get; private set; }


        public ControlDateType ControlDateType { get; private set; }
        public ControlDateModifierType ControlDateModifierType { get; private set; }
        public ControlDateOffsetType ControlDateOffsetType { get; private set; }
        public int? ControlDateOffsetValue { get; private set; }
    }
}
