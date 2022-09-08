using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using personality_test_api.Models.Request;
using personality_test_api.Models.Response;
using personality_test_api.Services;

namespace personality_test_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TestController : ControllerBase
    {
        private readonly ITestManager _testManager;
        private readonly IResultManager _resultManager;
        public TestController(ITestManager testManager, IResultManager resultManager)
        {
            _testManager = testManager;
            _resultManager = resultManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(TestIO), 200)]
        public IActionResult GetAll() => Ok(_testManager.GetAll());

        [HttpGet("{testId}")]
        [ProducesResponseType(typeof(TestIO), 200)]
        public IActionResult GetById(int testId) => Ok(_testManager.GetTestById(testId));


        [HttpGet("{testId}/result")]
        [ProducesResponseType(typeof(ResultRO), 200)]
        public IActionResult FindResult(int testId, [FromQuery] List<int> answers) => Ok(_resultManager.FindResult(testId,answers));
    }
}
