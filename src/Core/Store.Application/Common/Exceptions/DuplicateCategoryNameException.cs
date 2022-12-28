namespace Store.Application.Common.Exceptions
{
    public class DuplicateCategoryNameException : Exception
    {
        public DuplicateCategoryNameException(string message, Guid duplicateItemId) : base(message)
        {
            DuplicateItemId = duplicateItemId;
        }

        public Guid DuplicateItemId { get; }
    }
}
