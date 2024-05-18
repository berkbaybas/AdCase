using AdCase.Domain.Entities;

namespace AdCase.Domain.Helpers
{
    public static class GroupHelper
    {
        public static List<Domain.Entities.Group> InitializeGroups(int groupCount)
        {
            var groups = new List<AdCase.Domain.Entities.Group>();
            var groupNames = new[] { "A", "B", "C", "D", "E", "F", "G", "H" };

            for (int i = 0; i < groupCount; i++)
            {
                groups.Add(new Domain.Entities.Group { GroupName = groupNames[i] });
            }

            return groups;
        }
    }
}
