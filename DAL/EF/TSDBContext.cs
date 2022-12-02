using DAL.Entities;
using System.Data.Entity;
using System.Data.SqlClient;

namespace DAL.EF
{
    public class TSDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<UserTest> UserTests { get; set; }
        public DbSet<Report> Reports { get; set; }

        public static string GetRemoteConnectionString()
        {
            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
                DataSource = $"", 
                InitialCatalog = "",  
                IntegratedSecurity = false,
                MultipleActiveResultSets = true,
                UserID = Credentials.Login,
                Password = Credentials.Password
            };
            return sqlString.ToString();
        }
        public TSDBContext(): base(GetRemoteConnectionString()) { }

    }

}
