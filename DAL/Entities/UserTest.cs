using Newtonsoft.Json;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserTest
    {
        public int Id { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public Test Test { get; set; }
        public int TestId { get; set; }
        public IList<Result> Results { get; set; }

    }
}
