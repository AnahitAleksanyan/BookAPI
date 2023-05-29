namespace WebApplication4.Exceptions
{
    public class CustomValidationException : Exception
    {
        public string Message { get; set; }
        public List<string> Messages { get; set; }
        public CustomValidationException(string message) 
        {
            Message = message;
        }        
        public CustomValidationException(List<string> messages)
        {           
            this.Messages = messages;
        }
    }
}
