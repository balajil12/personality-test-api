using Microsoft.EntityFrameworkCore;
using personality_test_api.Models.Entities;

namespace personality_test_api.Db.Connections
{
    public class AppDb : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
    }
}
