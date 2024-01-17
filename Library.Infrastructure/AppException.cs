namespace Library.Infrastructure
{
    public class AppException : Exception
    {
        public bool IsRecoverable { get; }
        public bool IsShownToUser { get; }

        public AppException(string message, bool isRecoverable = false, bool isShownToUser = false)
            : base(message)
        {
            IsRecoverable = isRecoverable;
            IsShownToUser = isShownToUser;
        }

        public AppException RecoverableException(string message)
        {
            return new AppException(message, true, false);
        }
        public override string ToString()
        {
            return Message;
        }
    }
}
