using personality_test_api.Db.Connections;
using personality_test_api.Models.Entities;

namespace personality_test_api.Db.Repositories
{

    public interface IQuestionOptionRepository : IRepository<QuestionOption>{}

    public class QuestionOptionRepository : Repository<QuestionOption>, IQuestionOptionRepository
    {
        private readonly AppDb _db;
        public QuestionOptionRepository(AppDb db): base(db)
        {
            _db = db;
        }
    }
}
