namespace Store.Application.Common.Exceptions
{
    public class DuplicateProductNameException : Exception
    {
        public DuplicateProductNameException(string message, Guid duplicateItemId) : base(message)
        {
            DuplicateItemId = duplicateItemId;
        }

        public Guid DuplicateItemId { get; }
    }
}
