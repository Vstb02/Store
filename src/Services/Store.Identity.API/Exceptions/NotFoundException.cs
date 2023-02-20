using Store.Domain.Entities;

namespace Store.Identity.API.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string objectName)
            : base($"Запрошенный объект {objectName} не найден")
        {
        }
    }
}
