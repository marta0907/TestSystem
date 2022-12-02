namespace DAL.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string ActualAnswer { get; set; }
        public string ExpectedAnswer { get; set; }
        public Result Result { get; set; }
        public int ResultId { get; set; }
    }
}
