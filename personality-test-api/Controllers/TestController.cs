using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using personality_test_api.Models.Request;
using personality_test_api.Services;

namespace personality_test_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly ITestManager _testManager;
        public TestController(ITestManager testManager)
        {
            _testManager = testManager;
        }

        [HttpGet("{testId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(TestIO), 200)]
        public IActionResult GetById(int testId) => Ok(_testManager.GetTestById(testId));

    }
}
