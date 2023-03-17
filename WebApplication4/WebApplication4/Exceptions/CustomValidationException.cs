namespace WebApplication4.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException(string message) : base(message) { }
    }
}
