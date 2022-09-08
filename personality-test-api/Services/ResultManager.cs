using personality_test_api.Db.Repositories;
using personality_test_api.Models.Response;
using personality_test_api.Util;

namespace personality_test_api.Services
{
    public interface IResultManager
    {
        ResultRO FindResult(int testId, List<int> answers);
    }
    public class ResultManager : IResultManager
    {
        private readonly ITestResultRepository _testResultRepository;
        private readonly IQuestionManager _questionManager;
        public ResultManager(ITestResultRepository testResultRepository, IQuestionManager questionManager)
        {
            _testResultRepository = testResultRepository;
            _questionManager = questionManager;
        }

        public ResultRO FindResult(int testId, List<int> answers)
        {
            var questions = _questionManager.GetAllQuestions(testId).ToList();

            if (questions.Count != answers.Count || questions.Any(q => !q.Options.Any(r => answers.Contains(r.Id))))
                throw new CustomBadRequest("All questions are not asnwered");

            var optionsSelected = questions.Select(q => q.Options.Where(p => answers.Contains(p.Id)))
                .SelectMany(p => p).ToList();

            var score = optionsSelected.Average(q => q.Ratio);

            var result = _testResultRepository.FindResult(score);

            if (result == null)
                throw new InvalidDataException("Could not able to predict");

            return new ResultRO()
            {
                Conclusion = result.Conclusion,
                Description = result.Description
            };
        }
    }
}
