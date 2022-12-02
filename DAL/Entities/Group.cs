using System.Collections.Generic;

namespace DAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<GroupUser> GroupUsers { get; set; }

    }
}
