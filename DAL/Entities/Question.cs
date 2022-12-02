using Newtonsoft.Json;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int NumOfPoints { get; set; }
        public IList<Answer> Answers { get; set; }

        [JsonIgnore]
        public Test Test { get; set; }
        public int TestId { get; set; }
    }
}
