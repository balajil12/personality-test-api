using personality_test_api.Db.Repositories;
using personality_test_api.Models.Request;
using personality_test_api.Util;

namespace personality_test_api.Services
{
    public interface ITestManager
    {
        TestIO GetTestById(int testId);
    }
    public class TestManager : ITestManager
    {
        private readonly ITestRepository _testRepository;
        private readonly IQuestionManager _questionManager;
        public TestManager(ITestRepository testRepository, IQuestionManager questionManager)
        {
            _testRepository = testRepository;
            _questionManager = questionManager;
        }
        
        public TestIO GetTestById(int testId)
        {
            var test = _testRepository.GetById(testId);

            if (test == null)
                throw new CustomNotFound("Test not found");


            return new TestIO()
            {
                Description = test.Description,
                Name = test.Name,
                Id = test.Id,
                Questions = _questionManager.GetAllQuestions(testId)
            };
        }
    }
}
