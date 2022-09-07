using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using personality_test_api.Models.Request;
using personality_test_api.Models.Response;
using personality_test_api.Services;

namespace personality_test_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestResultController : ControllerBase
    {
        private readonly ITestManager _testManager;
        public TestResultController(ITestManager testManager)
        {
            _testManager = testManager;
        }

        [HttpGet("{testId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ResultRO), 200)]
        public IActionResult FindResult(int testId) => Ok(_testManager.GetTestById(testId));

    }
}
