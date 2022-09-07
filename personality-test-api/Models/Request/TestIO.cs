namespace personality_test_api.Models.Request
{
    public class TestIO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<QuestionIO> Questions { get; set; }
    }
}
