using Core.Entities.Enum;

namespace Core.Entities.Abstract
{
    public class BaseClass
    {
        public bool IsActive { get; set; } = true;
        public Stage Stage { get; set; } = Stage.Opportunity;
    }
}
