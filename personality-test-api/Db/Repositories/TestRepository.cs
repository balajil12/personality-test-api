using personality_test_api.Db.Connections;
using personality_test_api.Models.Entities;

namespace personality_test_api.Db.Repositories
{
    public interface ITestRepository : IRepository<Test> {}

    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(AppDb db): base(db) {}
    }
}
