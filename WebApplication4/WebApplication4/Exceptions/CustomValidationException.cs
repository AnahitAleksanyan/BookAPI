namespace WebApplication4.Exceptions
{
    public class CustomValidationException : Exception
    {

        public List<string> Messages { get; set; }
        public CustomValidationException(string message) : base(message) { }

        //ToDo ays constuctor@ chpetq e stana message, miyayn messages , qani vor du verevn arden unes message stacox constructor
        public CustomValidationException(string message, List<string> messages)
        {
           
            this.Messages = messages;
        }
    }
}
