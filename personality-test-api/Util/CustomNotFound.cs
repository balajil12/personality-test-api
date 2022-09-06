namespace personality_test_api.Util
{
    [Serializable]
    public class CustomNotFound : Exception
    {
        public CustomNotFound() { }

        public CustomNotFound(string message) : base(message)
        {
        }
    }
}
