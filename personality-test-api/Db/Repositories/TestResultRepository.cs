using personality_test_api.Db.Connections;
using personality_test_api.Models.Entities;

namespace personality_test_api.Db.Repositories
{
    public interface ITestResultRepository : IRepository<TestResult> 
    {
        TestResult? FindResult(double score);
    }

    public class TestResultRepository : Repository<TestResult>, ITestResultRepository
    {
        private readonly AppDb _db;
        public TestResultRepository(AppDb db): base(db)
        {
            _db = db;
        }

        public TestResult? FindResult(double score)
        {
            return _db.TestResults.Where(q=> q.LessThanEqual <= score)
                .OrderByDescending(q=> q.LessThanEqual).FirstOrDefault();
        }
    }
}
