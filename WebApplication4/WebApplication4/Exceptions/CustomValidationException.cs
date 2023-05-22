namespace WebApplication4.Exceptions
{
    public class CustomValidationException : Exception
    {

        public List<string> Messages { get; set; }
        public CustomValidationException(string message) : base(message) { }

        public CustomValidationException(string message, List<string> messages)
        {
           
            this.Messages = messages;
        }
    }
}
