using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using personality_test_api.Models.Request;
using personality_test_api.Services;

namespace personality_test_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionManager _questionManager;
        public QuestionController(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<QuestionIO>), 200)]
        public IActionResult GetAll() => Ok(_questionManager.GetAllQuestions());

        [HttpGet("{questionId}")]
        [ProducesResponseType(typeof(QuestionIO), 200)]
        public IActionResult GetById(int questionId) => Ok(_questionManager.GetQuestionById(questionId));

        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult Add(QuestionIO question)
        {
            _questionManager.AddQuestion(question);

            return Ok();
        }

        [HttpPut("{questionId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Update(int questionId, QuestionIO question)
        {
            _questionManager.UpdateQuestion(questionId, question);

            return Ok();
        }

        [HttpDelete("{questionId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteQuestion(int questionId)
        {
            _questionManager.DeleteQuestion(questionId);

            return Ok();
        }

        [HttpDelete("{questionId}/option/{optionId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteQuestion(int questionId, int optionId)
        {
            _questionManager.DeleteOption(questionId, optionId);

            return Ok();
        }
    }
}
