using Newtonsoft.Json;

namespace DAL.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsTrue { get; set; }

        [JsonIgnore]
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
