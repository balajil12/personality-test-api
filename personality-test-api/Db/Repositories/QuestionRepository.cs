using Microsoft.EntityFrameworkCore;
using personality_test_api.Db.Connections;
using personality_test_api.Models.Entities;

namespace personality_test_api.Db.Repositories
{

    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetAllQuestionsWithOptions(int testId);
        Question? GetQuestionWithOptions(int id);
    }

    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly AppDb _db;
        public QuestionRepository(AppDb db): base(db)
        {
            _db = db;
        }

        public IEnumerable<Question> GetAllQuestionsWithOptions(int testId) 
            => _db.Questions
                .Include(q => q.Options)
                .Where(q=> q.TestId == testId).AsNoTracking();
        public Question? GetQuestionWithOptions(int id) 
            => _db.Questions
                .Include(q => q.Options)
                .Where(q=> q.Id == id).AsNoTracking().FirstOrDefault();
    }
}
