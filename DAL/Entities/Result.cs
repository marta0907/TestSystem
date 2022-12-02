using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public int PointsGained { get; set; }
        public bool IsPassed { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public UserTest UserTest { get; set; }
        public int UserTestId { get; set; }
        [JsonIgnore]
        public IList<Report> UserAnswers { get; set; }

    }
}
