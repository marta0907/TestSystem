using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string InfoForTaker { get; set; }
        public string Title { get; set; }
        public float MinPassPercentage { get; set; }
        public string testPath { get; set; } = Guid.NewGuid().ToString() + ".json";
        public IList<Question> Questions { get; set; }
        public IList<UserTest> UserTests { get; set; }
    }
}
