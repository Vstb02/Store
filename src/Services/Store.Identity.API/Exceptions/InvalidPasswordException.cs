namespace Store.Identity.API.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() 
            : base("Неверный пароль")
        {
        }
    }
}
