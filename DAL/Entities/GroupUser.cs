using Newtonsoft.Json;

namespace DAL.Entities
{
    public class GroupUser
    {
        public int Id { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}
