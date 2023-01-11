namespace Store.Application.Common.Exceptions
{
    public class DuplicateBasketItemException : Exception
    {
        public DuplicateBasketItemException(string message, Guid duplicateItemId) : base(message)
        {
            DuplicateItemId = duplicateItemId;
        }

        public Guid DuplicateItemId { get; }
    }
}
