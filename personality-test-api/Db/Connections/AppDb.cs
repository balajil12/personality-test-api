using Microsoft.EntityFrameworkCore;
using personality_test_api.Models.Entities;
using System.IO;
using System.Reflection;

namespace personality_test_api.Db.Connections
{
    public class AppDb : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={Path.Join(AssemblyDirectory, "app.db")}");

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
