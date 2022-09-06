using personality_test_api.Db.Repositories;
using personality_test_api.Models.Entities;
using personality_test_api.Models.Request;
using personality_test_api.Util;
using System.Linq;

namespace personality_test_api.Services
{
    public interface IQuestionManager
    {
        void AddQuestion(QuestionIO question);
        void UpdateQuestion(QuestionIO question);
        void DeleteQuestion(int questionId);
        void DeleteOption(int questionId, int optionId);
        QuestionIO GetQuestionById(int questionId);
        IEnumerable<QuestionIO> GetAllQuestions();
    }
    public class QuestionManager : IQuestionManager
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionOptionRepository _qoRepository;
        public QuestionManager(IQuestionRepository questionRepository,
            IQuestionOptionRepository questionOptionRepository)
        {
            _questionRepository = questionRepository;
            _qoRepository = questionOptionRepository;
        }
        public void AddQuestion(QuestionIO question)
        {

            if (_questionRepository.Any(q => q.Description == question.Question))
                throw new CustomBadRequest("Question must be unique");

            var questionObj = new Question()
            {
                Description = question.Question,
            };
            _questionRepository.Create(questionObj);

            if (question.Options?.Any() == true)
            {
                var options = question.Options.Select(q => new QuestionOption()
                {
                    OptionText = q.Option,
                    Ratio = q.Ratio,
                    Question = questionObj
                }).ToList();
                questionObj.Options = options;
            }

            _questionRepository.Commit();
        }

        public void DeleteOption(int questionId, int optionId)
        {
            var option = _qoRepository.GetById(questionId);

            if (option == null)
                throw new CustomNotFound("Option not found");

            if (option.QuestionId != questionId)
                throw new CustomBadRequest("Question not found");

            _qoRepository.Delete(option);
            _qoRepository.Commit();
        }

        public void DeleteQuestion(int questionId)
        {
            var question = _questionRepository.GetQuestionWithOptions(questionId);


            if (question == null)
                throw new CustomNotFound("Question not found");

            if (question.Options.Any())
                _qoRepository.DeleteMultiple(question.Options.ToList());

            _questionRepository.Delete(question);
            _questionRepository.Commit();
        }

        public IEnumerable<QuestionIO> GetAllQuestions()
        {
            return _questionRepository.GetAll().Select(q => new QuestionIO()
            {
                Id = q.Id,
                Question = q.Description,
                Options = q.Options.Select(p => new OptionIO()
                {
                    Id = p.Id,
                    Option = p.OptionText,
                    Ratio = p.Ratio
                }).ToList()
            });
        }

        public QuestionIO GetQuestionById(int questionId)
        {
            var q = _questionRepository.GetQuestionWithOptions(questionId);

            if (q == null)
                throw new CustomNotFound("Question not found");

            return new QuestionIO()
            {
                Id = q.Id,
                Question = q.Description,
                Options = q.Options.Select(p => new OptionIO()
                {
                    Id = p.Id,
                    Option = p.OptionText,
                    Ratio = p.Ratio
                }).ToList()
            };
        }

        public void UpdateQuestion(QuestionIO question)
        {
            if (_questionRepository.Any(q => q.Description == question.Question && q.Id != question.Id))
                throw new CustomBadRequest("Question must be unique");

            var questionObj = _questionRepository.GetQuestionWithOptions(question.Id);

            if(questionObj ==null)
                throw new CustomNotFound("Question not found");

            questionObj.Description = question.Question;

            var entitiesToBeRemoved = questionObj.Options.Select(q => q.Id).ToList();

            if (question.Options?.Any() == true)
            {
                entitiesToBeRemoved.RemoveAll(q => question.Options.Any(p => p.Id == q));

                var options = question.Options.Select(q => new QuestionOption()
                {
                    OptionText = q.Option,
                    Id = q.Id,
                    Ratio = q.Ratio,
                    QuestionId = questionObj.Id
                }).ToList();
                questionObj.Options = options;
            }
            _questionRepository.Update(questionObj);

            if (entitiesToBeRemoved.Any())
            {
                _qoRepository.DeleteMultiple(questionObj.Options.Where(q=> entitiesToBeRemoved.Contains(q.Id)).ToList());
            }

            _questionRepository.Commit();
        }
    }
}
