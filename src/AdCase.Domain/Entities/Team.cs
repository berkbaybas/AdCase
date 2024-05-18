using AdCase.Domain.Common;

namespace AdCase.Domain.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; } 
        public string Country { get; set; }
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
