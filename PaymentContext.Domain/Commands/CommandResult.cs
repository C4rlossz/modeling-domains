using PaymentContext.Shared.Commands;


namespace PaymentContext.Domain.Commands
{
    public class commandResult : ICommandResult
    {
        public commandResult()
        {

        }        
        
        public commandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}