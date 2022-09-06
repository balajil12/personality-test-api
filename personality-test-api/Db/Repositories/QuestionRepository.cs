using Microsoft.EntityFrameworkCore;
using personality_test_api.Db.Connections;
using personality_test_api.Models.Entities;

namespace personality_test_api.Db.Repositories
{

    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetAllQuestionsWithOptions();
    }

    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly AppDb _db;
        public QuestionRepository(AppDb db): base(db)
        {
            _db = db;
        }

        public IEnumerable<Question> GetAllQuestionsWithOptions() => _db.Questions.Include(q => q.Options);
    }
}
