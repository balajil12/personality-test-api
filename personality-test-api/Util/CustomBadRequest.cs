namespace personality_test_api.Util
{
    [Serializable]
    public class CustomBadRequest : Exception
    {
        public CustomBadRequest() { }

        public CustomBadRequest(string message) : base(message)
        {
        }
    }
}
